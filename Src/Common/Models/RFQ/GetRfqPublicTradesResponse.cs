using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bybit.net.api.Models.RFQ
{
    public class GetRfqPublicTradesResponse
    {
        public GetRfqPublicTradesResult? result { get; set; }
    }

    public class GetRfqPublicTradesResult
    {
        public string? cursor { get; set; }
        public List<RfqPublicTradeItem>? list { get; set; }
    }

    public class RfqPublicTradeItem
    {
        public string? rfqId { get; set; }
        public string? strategyType { get; set; }
        public string? createdAt { get; set; }   // ms epoch
        public string? updatedAt { get; set; }   // ms epoch
        public List<RfqPublicTradeLeg>? legs { get; set; }
    }

    public class RfqPublicTradeLeg
    {
        public string? category { get; set; }    // linear | option | spot
        public string? symbol { get; set; }
        public string? side { get; set; }        // Buy | Sell
        public string? price { get; set; }
        public string? qty { get; set; }
        public string? markPrice { get; set; }
    }
}
