using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bybit.net.api.Models.Earn
{
    public class GetStakedPositionResult
    {
        public List<EarnStakedPosition>? list { get; set; }
    }

    public class EarnStakedPosition
    {
        public string? coin { get; set; }
        public string? productId { get; set; }
        public string? amount { get; set; }
        public string? totalPnl { get; set; }                      // Onchain non-LST only
        public string? claimableYield { get; set; }                // Not returned for Onchain
        public string? id { get; set; }                            // Onchain only
        public string? status { get; set; }                        // Processing, Active (Onchain)
        public string? orderId { get; set; }                       // Onchain only
        public string? estimateRedeemTime { get; set; }            // ms, Onchain only
        public string? estimateStakeTime { get; set; }             // ms, Onchain only
        public string? estimateInterestCalculationTime { get; set; } // ms, Onchain only
        public string? settlementTime { get; set; }                // ms, Onchain Fixed only
    }

}
