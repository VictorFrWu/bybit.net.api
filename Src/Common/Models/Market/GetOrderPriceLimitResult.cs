using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bybit.net.api.Models.Market
{
    public class GetOrderPriceLimitResult
    {
        public string? symbol { get; set; }
        public string? buyLmt { get; set; }
        public string? sellLmt { get; set; }
        public string? ts { get; set; }
    }

}
