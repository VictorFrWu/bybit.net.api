using bybit.net.api.Websockets;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace bybit.net.api.WebSocketStream
{
    public class SpotWebSocket : BybitWebSocket
    {
        private const string DEFAULT_ORDERBOOK_DATA_WEBSOCKET_BASE_URL = BybitConstants.WS_URL_PUBLIC + BybitConstants.V5_PUBLIC_SPOT;
        public SpotWebSocket(string url = DEFAULT_ORDERBOOK_DATA_WEBSOCKET_BASE_URL, int receiveBufferSize = 8192, string? apiKey = null, string? apiSecret = null)
            : base(new BybitWebSocketHandler(new ClientWebSocket()), url, receiveBufferSize, apiKey, apiSecret)
        {
        }

        public SpotWebSocket(IBybitWebSocketHandler handler, string url = DEFAULT_ORDERBOOK_DATA_WEBSOCKET_BASE_URL, int receiveBufferSize = 8192, string? apiKey = null, string? apiSecret = null) 
            : base(handler, url, receiveBufferSize, apiKey, apiSecret)
        {
        }
    }
}
