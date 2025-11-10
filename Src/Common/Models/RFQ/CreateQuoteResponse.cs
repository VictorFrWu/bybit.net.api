using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bybit.net.api.Models.RFQ
{
    public class CreateQuoteResponse
    {
        public CreateQuoteResult? result { get; set; }
    }

    public class CreateQuoteResult
    {
        public string? rfqId { get; set; }        // Inquiry ID
        public string? quoteId { get; set; }      // Quote ID
        public string? quoteLinkId { get; set; }  // Custom quote ID
        public string? expiresAt { get; set; }    // ms
        public string? deskCode { get; set; }     // quoter code
        public string? status { get; set; }       // Active | Canceled | Filled | Expired | Failed
    }
}
