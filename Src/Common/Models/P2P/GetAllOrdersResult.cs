using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bybit.net.api.Models.P2P
{
    public class GetAllOrdersResult
    {
        public int? count { get; set; }
        public List<P2pOrderItem>? items { get; set; }
    }

    public class P2pOrderItem
    {
        public string? id { get; set; }
        public int? side { get; set; }                 // 0 Buy, 1 Sell
        public string? tokenId { get; set; }
        public string? orderType { get; set; }         // ORIGIN | SMALL_COIN | WEB3
        public string? amount { get; set; }
        public string? currencyId { get; set; }
        public string? price { get; set; }
        public string? fee { get; set; }
        public string? targetNickName { get; set; }
        public string? targetUserId { get; set; }
        public int? status { get; set; }               // 5,10,20,30,40,50,60,70,80,90,100,110
        public string? createDate { get; set; }
        public string? transferLastSeconds { get; set; }
        public string? userId { get; set; }
        public string? sellerRealName { get; set; }
        public string? buyerRealName { get; set; }
        public P2pOrderExtension? Extension { get; set; }
    }

    public class P2pOrderExtension
    {
        public bool? isDelayWithdraw { get; set; }
        public string? delayTime { get; set; }
        public string? startTime { get; set; }
    }

}
