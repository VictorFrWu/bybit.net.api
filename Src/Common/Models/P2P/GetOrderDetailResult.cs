using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bybit.net.api.Models.P2P
{
    public class GetOrderDetailResult
    {
        public string? id { get; set; }
        public int? side { get; set; }                       // 0 Buy, 1 Sell
        public string? itemId { get; set; }
        public string? userId { get; set; }
        public string? nickName { get; set; }
        public string? makerUserId { get; set; }
        public string? targetUserId { get; set; }
        public string? targetNickName { get; set; }
        public string? targetConnectInformation { get; set; }
        public string? sellerRealName { get; set; }
        public string? buyerRealName { get; set; }
        public string? tokenId { get; set; }
        public string? currencyId { get; set; }
        public string? price { get; set; }
        public string? quantity { get; set; }
        public string? amount { get; set; }
        public int? paymentType { get; set; }
        public string? transferDate { get; set; }
        public int? status { get; set; }                      // 5,10,20,30,90,100,110
        public string? createDate { get; set; }
        public List<P2pPaymentTermDetail>? paymentTermList { get; set; }
        public string? remark { get; set; }
        public string? transferLastSeconds { get; set; }
        public string? appealContent { get; set; }
        public int? appealType { get; set; }
        public string? appealNickName { get; set; }
        public string? canAppeal { get; set; }
        public P2pPaymentTermDetail? confirmedPayTerm { get; set; }
        public string? makerFee { get; set; }
        public string? takerFee { get; set; }
        public P2pOrderExtensionDetail? extension { get; set; }
        public string? orderType { get; set; }                // ORIGIN | SMALL_COIN | WEB3
        public string? appealUserId { get; set; }
        public string? notifyTokenId { get; set; }
        public string? notifyTokenQuantity { get; set; }
        public string? cancelReason { get; set; }
        public bool? usedCoupon { get; set; }                 // true used, false not used
        public string? couponTokenId { get; set; }
        public string? couponQuantity { get; set; }
        public string? targetUserType { get; set; }           // PERSONAL | ORG
    }

    public class P2pPaymentTermDetail
    {
        public string? id { get; set; }
        public string? realName { get; set; }
        public int? paymentType { get; set; }
        public string? bankName { get; set; }
        public string? branchName { get; set; }
        public string? accountNo { get; set; }
        public string? qrcode { get; set; }
    }

    public class P2pOrderExtensionDetail
    {
        public bool? isDelayWithdraw { get; set; }
        public string? delayTime { get; set; }
        public string? startTime { get; set; }
    }

}
