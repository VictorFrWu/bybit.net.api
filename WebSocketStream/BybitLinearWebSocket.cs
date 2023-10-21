using bybit.net.api.Websockets;
using System.Net.WebSockets;

namespace bybit.net.api.WebSocketStream
{
    public class BybitLinearWebSocket : BybitWebSocket
    {
        public BybitLinearWebSocket(bool useTestNet = true, int receiveBufferSize = 8192, string? apiKey = null, string? apiSecret = null)
            : base(new BybitWebSocketHandler(new ClientWebSocket()), GetStreamUrl(useTestNet), receiveBufferSize, apiKey, apiSecret)
        {
        }

        public BybitLinearWebSocket(IBybitWebSocketHandler handler, bool useTestNet = true, int receiveBufferSize = 8192, string? apiKey = null, string? apiSecret = null)
            : base(handler, GetStreamUrl(useTestNet), receiveBufferSize, apiKey, apiSecret)
        {
        }

        private static string GetStreamUrl(bool useTestNet)
        {
            return useTestNet ? BybitConstants.LINEAR_MAINNET : BybitConstants.LINEAR_TESTNET;
        }
    }
}
