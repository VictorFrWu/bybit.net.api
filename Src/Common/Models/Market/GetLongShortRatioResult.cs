using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bybit.net.api.Models.Market
{
    public class GetLongShortRatioResult
    {
        public List<LongShortRatioItem>? list { get; set; }
        public string? nextPageCursor { get; set; }
    }

    public class LongShortRatioItem
    {
        public string? symbol { get; set; }
        public string? buyRatio { get; set; }
        public string? sellRatio { get; set; }
        public string? timestamp { get; set; }
    }

}
