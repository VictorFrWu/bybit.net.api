using bybit.net.api.Websockets;
using System.Net.WebSockets;

namespace bybit.net.api.WebSocketStream
{
    public class BybitLinearWebSocket : BybitWebSocket
    {
        public BybitLinearWebSocket(bool useTestNet = false, int pingIntevral = 20, int receiveBufferSize = 8192, string? apiKey = null, string? apiSecret = null)
            : base(new BybitWebSocketHandler(new ClientWebSocket()), GetStreamUrl(useTestNet), pingIntevral, receiveBufferSize, apiKey, apiSecret)
        {
        }

        public BybitLinearWebSocket(IBybitWebSocketHandler handler, bool useTestNet = false, int pingIntevral = 20, int receiveBufferSize = 8192, string? apiKey = null, string? apiSecret = null)
            : base(handler, GetStreamUrl(useTestNet), pingIntevral, receiveBufferSize, apiKey, apiSecret)
        {
        }

        private static string GetStreamUrl(bool useTestNet)
        {
            return !useTestNet ? BybitConstants.LINEAR_MAINNET : BybitConstants.LINEAR_TESTNET;
        }
    }
}
