using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bybit.net.api.Models.Affiliate
{
    public class GetAffiliateUserListResult
    {
        public List<AffiliateUser>? list { get; set; }
        public string? nextPageCursor { get; set; }
    }

    public class AffiliateUser
    {
        public string? userId { get; set; }
        public string? registerTime { get; set; }
        public int? source { get; set; }
        public int? remarks { get; set; }
        public bool? isKyc { get; set; }
        public string? takerVol30Day { get; set; }      // USDT
        public string? makerVol30Day { get; set; }      // USDT
        public string? tradeVol30Day { get; set; }      // USDT
        public string? depositAmount30Day { get; set; } // USDT
        public string? takerVol365Day { get; set; }     // USDT
        public string? makerVol365Day { get; set; }     // USDT
        public string? tradeVol365Day { get; set; }     // USDT
        public string? depositAmount365Day { get; set; }// USDT
    }

}
