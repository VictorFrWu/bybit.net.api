using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bybit.net.api.Models.NewCryptoLoan
{
    public class GetSupplyContractInfoFixedResult
    {
        public List<SupplyContractInfoFixed>? list { get; set; }
        public string? nextPageCursor { get; set; }
    }

    public class SupplyContractInfoFixed
    {
        public string? annualRate { get; set; }
        public string? supplyCurrency { get; set; }
        public string? supplyTime { get; set; }
        public string? supplyAmount { get; set; }
        public string? interestPaid { get; set; }
        public string? supplyId { get; set; }
        public string? orderId { get; set; }
        public string? redemptionTime { get; set; }
        public string? penaltyInterest { get; set; }
        public string? actualRedemptionTime { get; set; }
        public int? status { get; set; }  // 1 Supplying; 2 Redeemed
        public string? term { get; set; } // 7,14,30,90,180 (days)
    }

}
