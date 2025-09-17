using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bybit.net.api.Models.P2P
{
    public class GetAdsResult
    {
        public int? count { get; set; }
        public List<P2pAdItem>? items { get; set; }
    }

    public class P2pAdItem
    {
        public string? id { get; set; }
        public int? userId { get; set; }
        public string? nickName { get; set; }
        public string? tokenId { get; set; }
        public string? currencyId { get; set; }
        public string? side { get; set; }                 // "0" buy, "1" sell
        public string? price { get; set; }
        public string? lastQuantity { get; set; }
        public string? minAmount { get; set; }
        public string? maxAmount { get; set; }
        public List<string>? payments { get; set; }       // payment method type IDs
        public string? recentOrderNum { get; set; }
        public string? recentExecuteRate { get; set; }
        public bool? isOnline { get; set; }
        public string? lastLogoutTime { get; set; }
        public List<string>? authTag { get; set; }        // GA, VA, BA
        public int? paymentPeriod { get; set; }           // minutes
    }

}
