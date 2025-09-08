using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bybit.net.api.Models.Earn
{
    public class GetProductInfoResult
    {
        public List<EarnProduct>? list { get; set; }
    }

    public class EarnProduct
    {
        public string? category { get; set; }                 // FlexibleSaving, OnChain
        public string? estimateApr { get; set; }              // e.g., "3%", "4.25%"
        public string? coin { get; set; }
        public string? minStakeAmount { get; set; }
        public string? maxStakeAmount { get; set; }
        public string? precision { get; set; }
        public string? productId { get; set; }
        public string? status { get; set; }                   // Available, NotAvailable
        public List<BonusEvent>? bonusEvents { get; set; }
        public string? minRedeemAmount { get; set; }
        public string? maxRedeemAmount { get; set; }
        public string? duration { get; set; }                 // Fixed, Flexible
        public int? term { get; set; }                        // days, for OnChain Fixed
        public string? swapCoin { get; set; }
        public string? swapCoinPrecision { get; set; }
        public string? stakeExchangeRate { get; set; }
        public string? redeemExchangeRate { get; set; }
        public string? rewardDistributionType { get; set; }   // Simple, Compound, Other(LST)
        public int? rewardIntervalMinute { get; set; }
        public string? redeemProcessingMinute { get; set; }
        public string? stakeTime { get; set; }                // ms
        public string? interestCalculationTime { get; set; }  // ms
    }

    public class BonusEvent
    {
        public string? apr { get; set; }          // Yesterday's Rewards APR
        public string? coin { get; set; }         // Reward coin
        public string? announcement { get; set; } // link
    }

}
