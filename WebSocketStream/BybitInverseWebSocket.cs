using bybit.net.api.Websockets;
using System.Net.WebSockets;

namespace bybit.net.api.WebSocketStream
{
    public class BybitInverseWebSocket : BybitWebSocket
    {
        public BybitInverseWebSocket(bool useTestNet = true, int receiveBufferSize = 8192, string? apiKey = null, string? apiSecret = null)
            : base(new BybitWebSocketHandler(new ClientWebSocket()), GetStreamUrl(useTestNet), receiveBufferSize, apiKey, apiSecret)
        {
        }

        public BybitInverseWebSocket(IBybitWebSocketHandler handler, bool useTestNet = true, int receiveBufferSize = 8192, string? apiKey = null, string? apiSecret = null)
            : base(handler, GetStreamUrl(useTestNet), receiveBufferSize, apiKey, apiSecret)
        {
        }

        private static string GetStreamUrl(bool useTestNet)
        {
            return useTestNet ? BybitConstants.INVERSE_MAINNET : BybitConstants.INVERSE_TESTNET;
        }
    }
}
