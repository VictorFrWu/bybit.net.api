using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bybit.net.api.Models.RFQ
{
    public class ExecuteQuoteResponse
    {
        public ExecuteQuoteResult? result { get; set; }
    }

    public class ExecuteQuoteResult
    {
        public string? rfqId { get; set; }      // Inquiry ID
        public string? rfqLinkId { get; set; }
        public string? quoteId { get; set; }    // Quote ID
        public string? status { get; set; }     // PendingFill | Failed
    }
}
