using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bybit.net.api.Models.P2P
{
    public class GetAccountInformationResult
    {
        public string? nickName { get; set; }
        public bool? defaultNickName { get; set; }
        public bool? isOnline { get; set; }
        public string? kycLevel { get; set; }
        public string? email { get; set; }
        public string? mobile { get; set; }
        public string? lastLogoutTime { get; set; }
        public string? recentRate { get; set; }
        public int? totalFinishCount { get; set; }
        public int? totalFinishSellCount { get; set; }
        public int? totalFinishBuyCount { get; set; }
        public int? recentFinishCount { get; set; }
        public string? averageReleaseTime { get; set; }    // minutes
        public string? averageTransferTime { get; set; }   // minutes
        public int? accountCreateDays { get; set; }
        public int? firstTradeDays { get; set; }
        public string? realName { get; set; }
        public string? recentTradeAmount { get; set; }     // USDT
        public string? totalTradeAmount { get; set; }      // USDT
        public string? registerTime { get; set; }
        public int? authStatus { get; set; }               // 1 VA, 2 Not VA
        public string? kycCountryCode { get; set; }
        public string? blocked { get; set; }
        public string? goodAppraiseRate { get; set; }
        public int? goodAppraiseCount { get; set; }
        public int? badAppraiseCount { get; set; }
        public int? accountId { get; set; }
        public int? paymentCount { get; set; }
        public int? contactCount { get; set; }
        public int? vipLevel { get; set; }
        public int? userCancelCountLimit { get; set; }
        public bool? paymentRealNameUneditable { get; set; }
        public string? userId { get; set; }
        public string? realNameEn { get; set; }
    }

}
