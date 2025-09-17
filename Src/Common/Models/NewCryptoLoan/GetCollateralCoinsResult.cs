using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bybit.net.api.Models.NewCryptoLoan
{
    public class GetCollateralCoinsResult
    {
        public List<CollateralRatioConfig>? collateralRatioConfigList { get; set; }
        public List<CurrencyLiquidation>? currencyLiquidationList { get; set; }
    }

    public class CollateralRatioConfig
    {
        public List<CollateralRatioItem>? collateralRatioList { get; set; }
        public string? currencies { get; set; } // e.g., "BTC,ETH,XRP"
    }

    public class CollateralRatioItem
    {
        public string? collateralRatio { get; set; }
        public string? maxValue { get; set; }
        public string? minValue { get; set; }
    }

    public class CurrencyLiquidation
    {
        public string? currency { get; set; }
        public int? liquidationOrder { get; set; }
    }

}
