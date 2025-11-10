using bybit.net.api.Websockets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace bybit.net.api.WebSocketStream
{
    internal class BybitSpreadTradingWebSocket : BybitWebSocket
    {
        public BybitSpreadTradingWebSocket(bool useTestNet = false, int pingIntevral = 20, int receiveBufferSize = 8192, string? apiKey = null, string? apiSecret = null, bool debugMode = false)
            : base(new BybitWebSocketHandler(new ClientWebSocket()), GetStreamUrl(useTestNet), pingIntevral, receiveBufferSize, apiKey, apiSecret, debugMode)
        {
        }

        public BybitSpreadTradingWebSocket(IBybitWebSocketHandler handler, bool useTestNet = false, int pingIntevral = 20, int receiveBufferSize = 8192, string? apiKey = null, string? apiSecret = null, bool debugMode = false)
            : base(handler, GetStreamUrl(useTestNet), pingIntevral, receiveBufferSize, apiKey, apiSecret, debugMode)
        {
        }

        private static string GetStreamUrl(bool useTestNet)
        {
            return !useTestNet ? BybitConstants.WEBSOCKET_SPREAD_PUBLIC_MAINNET : BybitConstants.WEBSOCKET_SPREAD_PUBLIC_TESTNET;
        }
    }
}
