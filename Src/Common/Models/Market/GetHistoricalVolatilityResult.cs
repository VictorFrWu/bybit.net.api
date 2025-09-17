using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bybit.net.api.Models.Market
{
    public class GetHistoricalVolatilityResult
    {
        public string? category { get; set; }
        public List<HistoricalVolatilityItem>? list { get; set; }
    }

    public class HistoricalVolatilityItem
    {
        public int? period { get; set; }
        public string? value { get; set; }
        public string? time { get; set; }
    }

}
