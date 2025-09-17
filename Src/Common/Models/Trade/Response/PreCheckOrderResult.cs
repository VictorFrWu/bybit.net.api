using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bybit.net.api.Models.Trade.Response
{
    public class PreCheckOrderResult
    {
        public string? orderId { get; set; }
        public string? orderLinkId { get; set; }
        public int? preImrE4 { get; set; }
        public int? preMmrE4 { get; set; }
        public int? postImrE4 { get; set; }
        public int? postMmrE4 { get; set; }
    }
}
