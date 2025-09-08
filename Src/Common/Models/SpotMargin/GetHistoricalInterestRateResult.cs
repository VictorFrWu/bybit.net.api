using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bybit.net.api.Models.SpotMargin
{
    public class GetHistoricalInterestRateResult
    {
        public List<HistoricalInterestRateItem>? list { get; set; }
    }

    public class HistoricalInterestRateItem
    {
        public long? timestamp { get; set; }
        public string? currency { get; set; }
        public string? hourlyBorrowRate { get; set; }
        public string? vipLevel { get; set; }
    }

}
