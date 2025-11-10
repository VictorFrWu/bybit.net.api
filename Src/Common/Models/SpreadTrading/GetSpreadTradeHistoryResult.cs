using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bybit.net.api.Models.SpreadTrading
{
    public class GetSpreadTradeHistoryResult
    {
        public List<SpreadTrade>? list { get; set; }
        public string? nextPageCursor { get; set; }
    }

    public class SpreadTrade
    {
        public string? symbol { get; set; }        // Spread combination symbol name
        public string? orderLinkId { get; set; }   // User customised order ID
        public string? side { get; set; }          // Buy | Sell
        public string? orderId { get; set; }       // Spread combination order ID
        public string? execPrice { get; set; }     // Combo exec price
        public string? execTime { get; set; }      // Combo exec timestamp (ms)
        public string? execType { get; set; }      // Combo exec type, Trade
        public string? execQty { get; set; }       // Combo exec qty
        public string? execId { get; set; }        // Combo exec ID
        public List<SpreadTradeLeg>? legs { get; set; } // Legs execution info
    }

    public class SpreadTradeLeg
    {
        public string? symbol { get; set; }        // Leg symbol name
        public string? side { get; set; }          // Buy | Sell
        public string? execPrice { get; set; }     // Leg exec price
        public string? execTime { get; set; }      // Leg exec timestamp (ms)
        public string? execValue { get; set; }     // Leg exec value
        public string? execType { get; set; }      // Leg exec type
        public string? category { get; set; }      // linear | spot
        public string? execQty { get; set; }       // Leg exec qty
        public string? execFee { get; set; }       // Leg exec fee (deprecated for Spot)
        public string? execFeeV2 { get; set; }     // Leg exec fee (Spot only)
        public string? feeCurrency { get; set; }   // Leg fee currency
        public string? execId { get; set; }        // Leg exec ID
    }
}
