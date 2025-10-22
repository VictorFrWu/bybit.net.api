using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bybit.net.api.Models.SpreadTrading
{
    public class GetSpreadInstrumentsInfoResult
    {
        public List<SpreadInstrument>? list { get; set; }
        public string? nextPageCursor { get; set; }
    }

    public class SpreadInstrument
    {
        public string? symbol { get; set; }           // Spread combination symbol name
        public string? contractType { get; set; }     // FundingRateArb | CarryTrade | FutureSpread | PerpBasis
        public string? status { get; set; }           // Trading | Settling
        public string? baseCoin { get; set; }
        public string? quoteCoin { get; set; }
        public string? settleCoin { get; set; }
        public string? tickSize { get; set; }         // price tick
        public string? minPrice { get; set; }
        public string? maxPrice { get; set; }
        public string? lotSize { get; set; }          // qty precision
        public string? minSize { get; set; }
        public string? maxSize { get; set; }
        public string? launchTime { get; set; }       // ms timestamp
        public string? deliveryTime { get; set; }     // ms timestamp
        public List<SpreadInstrumentLeg>? legs { get; set; }
    }

    public class SpreadInstrumentLeg
    {
        public string? symbol { get; set; }           // Leg symbol name
        public string? contractType { get; set; }     // LinearPerpetual | LinearFutures | Spot
    }
}
