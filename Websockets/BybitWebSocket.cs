using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net.WebSockets;
using System.Security.Cryptography;
using System.Text;

namespace bybit.net.api.Websockets
{
    public class BybitWebSocket : IDisposable
    {
        private readonly IBybitWebSocketHandler handler;
        private readonly List<Func<string, Task>> onMessageReceivedFunctions;
        private readonly List<CancellationTokenRegistration> onMessageReceivedCancellationTokenRegistrations;
        private CancellationTokenSource? loopCancellationTokenSource;
        private readonly Uri url;
        private readonly int receiveBufferSize;
        private readonly string? apiKey;
        private readonly string? apiSecret;

        public BybitWebSocket(IBybitWebSocketHandler handler, string url, int receiveBufferSize = 8192, string? apiKey = null, string? apiSecret = null)
        {
            this.handler = handler;
            this.url = new Uri(url);
            this.receiveBufferSize = receiveBufferSize;
            this.apiKey = apiKey;
            this.apiSecret = apiSecret;
            this.onMessageReceivedFunctions = new List<Func<string, Task>>();
            this.onMessageReceivedCancellationTokenRegistrations = new List<CancellationTokenRegistration>();
        }

        #region Websocket Public Methods
        // <summary>
        /// Establishes a connection to the WebSocket. If required, sends an authentication and subscription request.
        /// </summary>
        /// <param name="args">Arguments for the subscription request.</param>
        /// <param name="cancellationToken">Token to signal the asynchronous operation to cancel.</param>
        /// <returns>A task that represents the asynchronous connect operation.</returns>
        /// <exception cref="BybitClientException">Thrown when a necessary parameter is missing or when the WebSocket is in an unexpected state.</exception>
        public async Task ConnectAsync(string[] args, CancellationToken cancellationToken)
        {
            if (this.handler.State != WebSocketState.Open)
            {
                this.loopCancellationTokenSource = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
                if (string.IsNullOrEmpty(url.AbsolutePath))
                    throw new BybitClientException("Please set up a websocket url", -1);
                await this.handler.ConnectAsync(this.url, cancellationToken);

                _ = Task.Run(() => Ping(this.loopCancellationTokenSource.Token), cancellationToken);

                if (RequiresAuthentication(url.AbsoluteUri))
                {
                    if (string.IsNullOrEmpty(apiKey) || string.IsNullOrEmpty(apiSecret))
                        throw new BybitClientException("Please set up your api key and api secret for private websocket channel", -1);
                    await SendAuth(apiKey, apiSecret);
                }
                await SendSubscription(args);
                await Task.Factory.StartNew(() => this.ReceiveLoop(this.loopCancellationTokenSource.Token, this.receiveBufferSize), this.loopCancellationTokenSource.Token, TaskCreationOptions.LongRunning, TaskScheduler.Default);
            }
        }

        /// <summary>
        /// Disconnects from the WebSocket gracefully.
        /// </summary>
        /// <param name="cancellationToken">Token to signal the asynchronous operation to cancel.</param>
        /// <returns>A task that represents the asynchronous disconnect operation.</returns>
        public async Task DisconnectAsync(CancellationToken cancellationToken)
        {
            if (this.loopCancellationTokenSource != null)
            {
                this.loopCancellationTokenSource.Cancel();
            }

            if (this.handler.State == WebSocketState.Open)
            {
                await this.handler.CloseOutputAsync(WebSocketCloseStatus.NormalClosure, cancellationToken);
                await this.handler.CloseAsync(WebSocketCloseStatus.NormalClosure, cancellationToken);
            }
        }

        /// <summary>
        /// Registers a callback function to be invoked when a new message is received from the WebSocket.
        /// </summary>
        /// <param name="onMessageReceived">Callback function to handle the received message.</param>
        /// <param name="cancellationToken">Token to signal the callback registration to cancel.</param>
        public void OnMessageReceived(Func<string, Task> onMessageReceived, CancellationToken cancellationToken)
        {
            this.onMessageReceivedFunctions.Add(onMessageReceived);

            if (cancellationToken != CancellationToken.None)
            {
                var reg = cancellationToken.Register(() =>
                    this.onMessageReceivedFunctions.Remove(onMessageReceived));

                this.onMessageReceivedCancellationTokenRegistrations.Add(reg);
            }
        }

        /// <summary>
        /// Sends a message to the WebSocket.
        /// </summary>
        /// <param name="message">Message content to send.</param>
        /// <param name="cancellationToken">Token to signal the asynchronous operation to cancel.</param>
        /// <returns>A task that represents the asynchronous send operation.</returns>
        public async Task SendAsync(string message, CancellationToken cancellationToken)
        {
            byte[] byteArray = Encoding.ASCII.GetBytes(message);

            await this.handler.SendAsync(new ArraySegment<byte>(byteArray), WebSocketMessageType.Text, true, cancellationToken);
        }

        /// <summary>
        /// Releases all resources used by the current instance of the WebSocket and ensures a graceful disconnection.
        /// </summary>
        public void Dispose()
        {
            this.DisconnectAsync(CancellationToken.None).Wait();

            this.handler.Dispose();

            this.onMessageReceivedCancellationTokenRegistrations.ForEach(ct => ct.Dispose());

            if (loopCancellationTokenSource != null) this.loopCancellationTokenSource.Dispose();
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Determines if the provided path requires authentication.
        /// </summary>
        /// <param name="path">The API path to be checked.</param>
        /// <returns>True if authentication is required, otherwise False.</returns>
        private bool RequiresAuthentication(string path) => BybitConstants.WEBSOCKET_PRIVATE_MAINNET.Equals(path) ||
                    BybitConstants.WEBSOCKET_PRIVATE_TESTNET.Equals(path) ||
                    BybitConstants.V3_CONTRACT_PRIVATE.Equals(path) ||
                    BybitConstants.V3_UNIFIED_PRIVATE.Equals(path) ||
                    BybitConstants.V3_SPOT_PRIVATE.Equals(path);

        /// <summary>
        /// Sends an authentication request to the WebSocket using the provided key and secret.
        /// </summary>
        /// <param name="key">The API key for authentication.</param>
        /// <param name="secret">The API secret for generating the signature.</param>
        /// <returns>A task that represents the asynchronous authentication operation.</returns>
        private async Task SendAuth(string key, string secret)
        {
            long expires = DateTimeOffset.Now.ToUnixTimeMilliseconds() + 10000;
            string _val = $"GET/realtime{expires}";

            var hmacsha256 = new HMACSHA256(Encoding.UTF8.GetBytes(secret));
            var hash = hmacsha256.ComputeHash(Encoding.UTF8.GetBytes(_val));
            string signature = BitConverter.ToString(hash).Replace("-", "").ToLower();

            var authMessage = new { req_id = Guid.NewGuid().ToString(), op = "auth", args = new object[] { key, expires, signature } };
            string authMessageJson = JsonConvert.SerializeObject(authMessage);
            await Console.Out.WriteLineAsync(authMessageJson);
            await SendAsync(authMessageJson, CancellationToken.None);
        }

        /// <summary>
        /// Sends a subscription request to the WebSocket using the provided arguments.
        /// </summary>
        /// <param name="args">Arguments for the subscription request.</param>
        /// <returns>A task that represents the asynchronous subscription operation.</returns>
        private async Task SendSubscription(string[] args)
        {
            BybitParametersUtils.EnsureNoDuplicates(args);
            var subMessage = new { req_id = Guid.NewGuid().ToString(), op = "subscribe", args = args };
            string subMessageJson = JsonConvert.SerializeObject(subMessage);
            await Console.Out.WriteLineAsync($"send subscription {subMessageJson}");
            await SendAsync(subMessageJson, CancellationToken.None);
        }

        /// <summary>
        /// Periodically sends a "ping" message to keep the WebSocket connection alive.
        /// </summary>
        /// <param name="token">Token to signal the asynchronous operation to cancel.</param>
        /// <returns>A task that represents the asynchronous ping operation.</returns>
        private async Task Ping(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                await Task.Delay(TimeSpan.FromSeconds(10), token);
                if (this.handler.State == WebSocketState.Open)
                {
                    await SendAsync("ping", CancellationToken.None);
                    await Console.Out.WriteLineAsync("ping sent");
                }
            }
        }

        /// <summary>
        /// Listens for incoming messages from the WebSocket and processes them.
        /// </summary>
        /// <param name="cancellationToken">Token to signal the asynchronous operation to cancel.</param>
        /// <param name="receiveBufferSize">Size of the buffer used to receive messages.</param>
        /// <returns>A task that represents the asynchronous receive operation.</returns>
        private async Task ReceiveLoop(CancellationToken cancellationToken, int receiveBufferSize = 8192)
        {
            WebSocketReceiveResult receiveResult;
            try
            {
                while (!cancellationToken.IsCancellationRequested)
                {
                    var buffer = new ArraySegment<byte>(new byte[receiveBufferSize]);
                    receiveResult = await this.handler.ReceiveAsync(buffer, cancellationToken);

                    if (receiveResult.MessageType == WebSocketMessageType.Close)
                    {
                        break;
                    }

                    string content = Encoding.UTF8.GetString(buffer.ToArray(), buffer.Offset, buffer.Count);
                    this.onMessageReceivedFunctions.ForEach(omrf => omrf(content));
                }
            }
            catch (TaskCanceledException)
            {
                await this.DisconnectAsync(CancellationToken.None);
            }
        }
        #endregion
    }
}
