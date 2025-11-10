using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bybit.net.api.Models.RFQ
{
    public class GetRfqListResponse
    {
        public GetRfqListResult? result { get; set; }
    }

    public class GetRfqListResult
    {
        public string? cursor { get; set; }
        public List<RfqItem>? list { get; set; }
    }

    public class RfqItem
    {
        public string? rfqId { get; set; }
        public string? rfqLinkId { get; set; }
        public List<string>? counterparties { get; set; }
        public string? expiresAt { get; set; }
        public string? strategyType { get; set; }
        public string? status { get; set; }       // Active | PendingFill | Canceled | Filled | Expired | Failed
        public string? deskCode { get; set; }
        public string? createdAt { get; set; }    // ms epoch
        public string? updatedAt { get; set; }    // ms epoch
        public List<RfqLeg>? legs { get; set; }   // reused schema
    }
}
