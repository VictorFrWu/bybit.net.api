using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bybit.net.api.Models.Asset
{
    public class GetConvertCoinListResult
    {
        public List<ConvertCoin>? coins { get; set; }
    }

    public class ConvertCoin
    {
        public string? coin { get; set; }
        public string? fullName { get; set; }
        public string? icon { get; set; }
        public string? iconNight { get; set; }
        public int? accuracyLength { get; set; }
        public string? coinType { get; set; }
        public string? balance { get; set; }
        public string? uBalance { get; set; }
        public string? singleFromMinLimit { get; set; }
        public string? singleFromMaxLimit { get; set; }
        public bool? disableFrom { get; set; }
        public bool? disableTo { get; set; }
        public int? timePeriod { get; set; }
        public string? singleToMinLimit { get; set; }
        public string? singleToMaxLimit { get; set; }
        public string? dailyFromMinLimit { get; set; }
        public string? dailyFromMaxLimit { get; set; }
        public string? dailyToMinLimit { get; set; }
        public string? dailyToMaxLimit { get; set; }
    }

}
