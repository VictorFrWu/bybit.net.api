using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bybit.net.api.Models.RFQ
{
    public class GetQuoteRealtimeResponse
    {
        public List<RfqQuoteRealtimeItem>? list { get; set; }
    }

    public class RfqQuoteRealtimeItem
    {
        public string? rfqId { get; set; }            // Inquiry ID
        public string? rfqLinkId { get; set; }        // Custom RFQ ID (not public)
        public string? quoteId { get; set; }          // Quote ID
        public string? quoteLinkId { get; set; }      // Custom quote ID (not public)
        public string? expiresAt { get; set; }        // ms
        public string? deskCode { get; set; }         // inquirer desk code (hidden if anonymous)
        public string? status { get; set; }           // Active | PendingFill | Canceled | Filled | Expired | Failed
        public string? execQuoteSide { get; set; }    // Buy | Sell
        public string? createdAt { get; set; }        // ms epoch
        public string? updatedAt { get; set; }        // ms epoch
        public List<RfqLeg>? quoteBuyList { get; set; }
        public List<RfqLeg>? quoteSellList { get; set; }
    }
}
