using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bybit.net.api.Models.RFQ
{
    public class CreateRfqResponse
    {
        public List<string>? result { get; set; }          // Order ID list
        public List<CreateRfqItem>? list { get; set; }     // RFQ info
    }

    public class CreateRfqItem
    {
        public string? rfqId { get; set; }       // Inquiry ID
        public string? rfqLinkId { get; set; }   // Custom inquiry ID
        public string? status { get; set; }      // Active | Canceled | Filled | Expired | Failed
        public string? expiresAt { get; set; }   // ms
        public string? deskCode { get; set; }    // Inquirer unique code
    }
}
