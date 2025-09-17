using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bybit.net.api.Models.Affiliate
{
    public class GetAffiliateUserInfoResult
    {
        public string? uid { get; set; }
        public string? vipLevel { get; set; }
        public string? takerVol30Day { get; set; }       // USDT
        public string? makerVol30Day { get; set; }       // USDT
        public string? tradeVol30Day { get; set; }       // USDT
        public string? depositAmount30Day { get; set; }  // USDT, ~5 min update
        public string? takerVol365Day { get; set; }      // USDT
        public string? makerVol365Day { get; set; }      // USDT
        public string? tradeVol365Day { get; set; }      // USDT
        public string? depositAmount365Day { get; set; } // USDT, ~5 min update
        public string? totalWalletBalance { get; set; }  // 1..4
        public string? depositUpdateTime { get; set; }   // UTC
        public string? volUpdateTime { get; set; }       // UTC
        public int? KycLevel { get; set; }               // 0,1,2
    }

}
