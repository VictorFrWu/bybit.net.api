using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bybit.net.api.Models.RFQ
{
    public class GetRfqTradeListResponse
    {
        public GetRfqTradeListResult? result { get; set; }
    }

    public class GetRfqTradeListResult
    {
        public string? cursor { get; set; }
        public List<RfqTradeItem>? list { get; set; }
    }

    public class RfqTradeItem
    {
        public string? rfqId { get; set; }            // Inquiry ID
        public string? rfqLinkId { get; set; }        // Custom RFQ ID (not public)
        public string? quoteId { get; set; }          // Executed quote ID
        public string? quoteLinkId { get; set; }      // Custom quote ID (not public)
        public string? quoteSide { get; set; }        // Buy | Sell
        public string? strategyType { get; set; }     // Inquiry label
        public string? status { get; set; }           // Filled | Failed
        public string? rfqDeskCode { get; set; }      // inquirer desk code (hidden if anonymous)
        public string? quoteDeskCode { get; set; }    // quoter desk code (hidden if anonymous)
        public string? createdAt { get; set; }        // ms epoch
        public string? updatedAt { get; set; }        // ms epoch
        public List<RfqTradeLeg>? legs { get; set; }  // legs
    }

    public class RfqTradeLeg
    {
        public string? category { get; set; }     // linear | option | spot
        public string? orderId { get; set; }      // bybit order id
        public string? symbol { get; set; }       // instrument ID
        public string? side { get; set; }         // Buy | Sell
        public string? price { get; set; }        // execution price
        public string? qty { get; set; }          // executed quantity
        public string? markPrice { get; set; }    // futures markPrice / spot indexPrice / option underlying mark
        public string? execFee { get; set; }      // fee (base currency)
        public string? execId { get; set; }       // unique trade ID
        public int? resultCode { get; set; }      // 0 means success
        public string? resultMessage { get; set; }//
        public string? rejectParty { get; set; }  // Taker | Maker | bybit (when rejected)
    }
}
