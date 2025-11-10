using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bybit.net.api.Models.RFQ
{
    public class GetRfqRealtimeResponse
    {
        public List<RfqRealtimeItem>? list { get; set; }
    }

    public class RfqRealtimeItem
    {
        public string? rfqId { get; set; }                  // Inquiry ID
        public string? rfqLinkId { get; set; }              // Custom RFQ ID (not public)
        public List<string>? counterparties { get; set; }   // bidders
        public string? expiresAt { get; set; }              // ms
        public string? strategyType { get; set; }           // inquiry label
        public string? status { get; set; }                 // Active | PendingFill | Canceled | Filled | Expired | Failed
        public string? deskCode { get; set; }               // inquirer desk code (hidden if anonymous)
        public string? createdAt { get; set; }              // ms epoch
        public string? updatedAt { get; set; }              // ms epoch
        public List<RfqLeg>? legs { get; set; }     // combo legs
    }
}
