using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bybit.net.api.Models.SpotMargin
{
    public class GetTieredCollateralRatioResult
    {
        public List<TieredCollateralCurrency>? list { get; set; }
    }

    public class TieredCollateralCurrency
    {
        public string? currency { get; set; }
        public List<CollateralRatioTier>? collateralRatioList { get; set; }
    }

    public class CollateralRatioTier
    {
        public string? maxQty { get; set; }          // "" means +∞
        public string? minQty { get; set; }
        public string? collateralRatio { get; set; }
    }

}
