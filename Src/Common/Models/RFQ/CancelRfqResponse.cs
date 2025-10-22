using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bybit.net.api.Models.RFQ
{
    public class CancelRfqResponse
    {
        public string? rfqId { get; set; }     // Inquiry ID
        public string? rfqLinkId { get; set; } // Custom inquiry ID
    }
}
