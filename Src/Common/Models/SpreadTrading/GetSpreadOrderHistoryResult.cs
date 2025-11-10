using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bybit.net.api.Models.SpreadTrading
{
    public class GetSpreadOrderHistoryResult
    {
        public List<SpreadOrderHistoryItem>? list { get; set; }
        public string? nextPageCursor { get; set; }
    }

    public class SpreadOrderHistoryItem
    {
        public string? symbol { get; set; }          // Spread combination symbol name
        public string? orderType { get; set; }       // Market | Limit
        public string? orderLinkId { get; set; }
        public string? orderId { get; set; }
        public string? contractType { get; set; }    // FundingRateArb | CarryTrade | FutureSpread | PerpBasis
        public string? cxlRejReason { get; set; }    // Reject reason
        public string? orderStatus { get; set; }     // Rejected | Cancelled | Filled
        public string? price { get; set; }
        public string? orderQty { get; set; }
        public string? timeInForce { get; set; }     // GTC | FOK | IOC | PostOnly
        public string? baseCoin { get; set; }
        public string? createdAt { get; set; }       // ms timestamp
        public string? updatedAt { get; set; }       // ms timestamp
        public string? side { get; set; }            // Buy | Sell
        public string? leavesQty { get; set; }       // Remaining qty (meaningless if cancelled)
        public string? settleCoin { get; set; }
        public string? cumExecQty { get; set; }
        public string? qty { get; set; }
        public string? leg1Symbol { get; set; }
        public string? leg1ProdType { get; set; }    // Futures | Spot
        public string? leg1OrderId { get; set; }
        public string? leg1Side { get; set; }
        public string? leg2ProdType { get; set; }    // Futures | Spot
        public string? leg2OrderId { get; set; }
        public string? leg2Symbol { get; set; }
        public string? leg2Side { get; set; }        // typo in docs: "orde" -> "order"
    }
}
