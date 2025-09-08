using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bybit.net.api.Models.P2P
{
    public class GetMyAdsResult
    {
        public int? count { get; set; }
        public bool? hiddenFlag { get; set; }
        public List<MyAdItem>? items { get; set; }
    }

    public class MyAdItem
    {
        public string? id { get; set; }
        public string? accountId { get; set; }
        public string? userId { get; set; }
        public string? nickName { get; set; }
        public string? tokenId { get; set; }
        public string? currencyId { get; set; }
        public int? side { get; set; }                 // 0 buy; 1 sell
        public int? priceType { get; set; }            // 0 fixed; 1 floating
        public string? price { get; set; }
        public string? premium { get; set; }
        public string? lastQuantity { get; set; }
        public string? quantity { get; set; }
        public string? frozenQuantity { get; set; }
        public string? executedQuantity { get; set; }
        public string? minAmount { get; set; }
        public string? maxAmount { get; set; }
        public string? remark { get; set; }
        public int? status { get; set; }               // 10 online; 20 offline; 30 completed
        public string? createDate { get; set; }        // timestamp
        public List<string>? payments { get; set; }
        public TradingPreferenceSetMyAd? tradingPreferenceSet { get; set; }
        public string? updateDate { get; set; }        // timestamp
        public string? feeRate { get; set; }
        public int? paymentPeriod { get; set; }        // minutes
        public string? itemType { get; set; }          // ORIGIN | BULK
        public List<PaymentTerm>? paymentTerms { get; set; }
    }

    public class TradingPreferenceSetMyAd
    {
        public int? hasUnPostAd { get; set; }
        public int? isKyc { get; set; }
        public int? isEmail { get; set; }
        public int? isMobile { get; set; }
        public int? registerTimeThreshold { get; set; }
        public int? orderFinishNumberDay30 { get; set; }
        public string? completeRateDay30 { get; set; }
        public string? nationalLimit { get; set; }
        public int? hasOrderFinishNumberDay30 { get; set; }
        public int? hasCompleteRateDay30 { get; set; }
        public int? hasNationalLimit { get; set; }
    }

    public class PaymentTerm
    {
        public string? id { get; set; }
        public string? paymentType { get; set; }
    }

}
