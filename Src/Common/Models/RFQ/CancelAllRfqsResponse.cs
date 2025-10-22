using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bybit.net.api.Models.RFQ
{
    public class CancelAllRfqsResponse
    {
        public List<CancelAllRfqItem>? result { get; set; }
    }

    public class CancelAllRfqItem
    {
        public string? rfqId { get; set; }      // Inquiry ID
        public string? rfqLinkId { get; set; }  // Custom inquiry ID
        public string? code { get; set; }       // "0" means success
        public string? msg { get; set; }        // failure reason if any
    }
}
