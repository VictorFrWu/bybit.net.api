using bybit.net.api.Websockets;
using System.Net.WebSockets;

namespace bybit.net.api.WebSocketStream
{
    public class BybitPrivateWebsocket : BybitWebSocket
    {
        public BybitPrivateWebsocket(string apiKey, string apiSecret, bool useTestNet = false, int receiveBufferSize = 8192)
            : base(new BybitWebSocketHandler(new ClientWebSocket()), GetStreamUrl(useTestNet), receiveBufferSize, apiKey, apiSecret)
        {
            if (string.IsNullOrEmpty(apiKey) || string.IsNullOrEmpty(apiSecret))
                throw new BybitClientException("API key and API secret are required for private websocket channel", -1);
        }

        public BybitPrivateWebsocket(IBybitWebSocketHandler handler, string apiKey, string apiSecret, bool useTestNet = false, int receiveBufferSize = 8192)
            : base(handler, GetStreamUrl(useTestNet), receiveBufferSize, apiKey, apiSecret)
        {
            if (string.IsNullOrEmpty(apiKey) || string.IsNullOrEmpty(apiSecret))
                throw new BybitClientException("API key and API secret are required for private websocket channel", -1);
        }

        private static string GetStreamUrl(bool useTestNet)
        {
            return !useTestNet ? BybitConstants.WEBSOCKET_PRIVATE_MAINNET : BybitConstants.WEBSOCKET_PRIVATE_TESTNET;
        }
    }
}
