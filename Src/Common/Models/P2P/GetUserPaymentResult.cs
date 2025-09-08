using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bybit.net.api.Models.P2P
{
    public class GetUserPaymentResult
    {
        public List<UserPaymentItem>? result { get; set; }
    }

    public class UserPaymentItem
    {
        public string? id { get; set; }
        public string? realName { get; set; }
        public string? paymentType { get; set; }
        public string? bankName { get; set; }
        public string? branchName { get; set; }
        public string? accountNo { get; set; }
        public string? qrcode { get; set; }
        public string? online { get; set; }                     // "0" Offline, "1" Online
        public int? visible { get; set; }
        public string? payMessage { get; set; }
        public string? firstName { get; set; }
        public string? lastName { get; set; }
        public string? secondLastName { get; set; }
        public string? clabe { get; set; }
        public string? debitCardNumber { get; set; }
        public string? concept { get; set; }
        public string? countNo { get; set; }
        public string? paymentExt1 { get; set; }
        public string? paymentExt2 { get; set; }
        public string? paymentExt3 { get; set; }
        public string? paymentExt4 { get; set; }
        public string? paymentExt5 { get; set; }
        public string? paymentExt6 { get; set; }
        public int? paymentTemplateVersion { get; set; }
        public bool? hasPaymentTemplateChanged { get; set; }
        public PaymentConfigVo? paymentConfigVo { get; set; }
        public bool? realNameVerified { get; set; }
        public string? channel { get; set; }
        public List<object>? currencyBalance { get; set; }
    }

    public class PaymentConfigVo
    {
        public string? paymentType { get; set; }
        public int? checkType { get; set; }
        public int? sort { get; set; }
        public string? paymentName { get; set; }
        public string? addTips { get; set; }
        public string? itemTips { get; set; }
        public int? online { get; set; }               // 0 Offline, 1 Online
        public List<object>? items { get; set; }
    }

}
