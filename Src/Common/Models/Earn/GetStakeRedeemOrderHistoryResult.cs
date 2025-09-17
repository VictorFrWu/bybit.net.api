using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bybit.net.api.Models.Earn
{
    public class GetStakeRedeemOrderHistoryResult
    {
        public List<EarnOrderHistoryItem>? list { get; set; }
    }

    public class EarnOrderHistoryItem
    {
        public string? coin { get; set; }
        public string? orderValue { get; set; }
        public string? orderType { get; set; }       // Redeem, Stake
        public string? orderId { get; set; }
        public string? orderLinkId { get; set; }
        public string? status { get; set; }          // Success, Fail, Pending
        public string? createdAt { get; set; }       // ms
        public string? productId { get; set; }
        public string? updatedAt { get; set; }       // ms
        public string? swapOrderValue { get; set; }  // LST Onchain only
        public string? estimateRedeemTime { get; set; } // Onchain only, ms
        public string? estimateStakeTime { get; set; }  // Onchain only, ms
    }

}
