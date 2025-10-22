using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bybit.net.api.Models.SpreadTrading
{
    public class GetSpreadOpenOrdersResult
    {
        public List<SpreadOpenOrder>? list { get; set; }
        public string? nextPageCursor { get; set; }
    }

    public class SpreadOpenOrder
    {
        public string? symbol { get; set; }          // Spread combination symbol name
        public string? baseCoin { get; set; }        // Base coin
        public string? orderType { get; set; }       // Market | Limit
        public string? orderLinkId { get; set; }     // User customised order ID
        public string? side { get; set; }            // Buy | Sell
        public string? timeInForce { get; set; }     // GTC | FOK | IOC | PostOnly
        public string? orderId { get; set; }         // Spread combination order ID
        public string? leavesQty { get; set; }       // Remaining qty not executed
        public string? orderStatus { get; set; }     // New | PartiallyFilled
        public string? cumExecQty { get; set; }      // Cumulative executed qty
        public string? price { get; set; }           // Order price
        public string? qty { get; set; }             // Order qty
        public string? createdTime { get; set; }     // ms timestamp
        public string? updatedTime { get; set; }     // ms timestamp
    }
}
