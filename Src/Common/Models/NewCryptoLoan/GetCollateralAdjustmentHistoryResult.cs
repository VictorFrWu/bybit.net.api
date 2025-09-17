using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bybit.net.api.Models.NewCryptoLoan
{
    public class GetCollateralAdjustmentHistoryResult
    {
        public List<CollateralAdjustmentItem>? list { get; set; }
        public string? nextPageCursor { get; set; }
    }

    public class CollateralAdjustmentItem
    {
        public string? collateralCurrency { get; set; }
        public string? amount { get; set; }
        public long? adjustId { get; set; }
        public long? adjustTime { get; set; }
        public string? preLTV { get; set; }
        public string? afterLTV { get; set; }
        public int? direction { get; set; } // 0 add, 1 reduce
        public int? status { get; set; }    // 1 success, 2 processing, 3 fail
    }

}
