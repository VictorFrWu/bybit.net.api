using System.Net.WebSockets;
namespace bybit.net.api.Websockets
{
    /// <summary>
    /// Bybit humble object for <see cref="System.Net.WebSockets.ClientWebSocket" />.
    /// </summary>
    public class BybitWebSocketHandler : IBybitWebSocketHandler
    {
        private static readonly string UserAgent = "bybit.net.api/" + VersionInfo.GetVersion;

        private readonly ClientWebSocket webSocket;

        public BybitWebSocketHandler(ClientWebSocket clientWebSocket)
        {
            this.webSocket = clientWebSocket ?? throw new ArgumentNullException(nameof(clientWebSocket));
            this.webSocket.Options.SetRequestHeader("User-Agent", UserAgent);
        }

        public WebSocketState State
        {
            get
            {
                return this.webSocket.State;
            }
        }

        public async Task ConnectAsync(Uri uri, CancellationToken cancellationToken)
        {
            await this.webSocket.ConnectAsync(uri, cancellationToken);
        }

        public async Task CloseOutputAsync(WebSocketCloseStatus closeStatus, CancellationToken cancellationToken, string? statusDescription = null)
        {
            await this.webSocket.CloseOutputAsync(closeStatus, statusDescription, cancellationToken);
        }

        public async Task CloseAsync(WebSocketCloseStatus closeStatus, CancellationToken cancellationToken, string? statusDescription = null)
        {
            await this.webSocket.CloseAsync(closeStatus, statusDescription, cancellationToken);
        }

        public async Task<WebSocketReceiveResult> ReceiveAsync(ArraySegment<byte> buffer, CancellationToken cancellationToken)
        {
            return await this.webSocket.ReceiveAsync(buffer, cancellationToken);
        }

        public async Task SendAsync(ArraySegment<byte> buffer, WebSocketMessageType messageType, bool endOfMessage, CancellationToken cancellationToken)
        {
            await this.webSocket.SendAsync(buffer, messageType, endOfMessage, cancellationToken);
        }

        public void Dispose() => this.webSocket.Dispose();
    }
}
