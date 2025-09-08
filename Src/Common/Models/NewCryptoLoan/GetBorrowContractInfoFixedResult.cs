using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bybit.net.api.Models.NewCryptoLoan
{
    public class GetBorrowContractInfoFixedResult
    {
        public List<BorrowContractInfoFixed>? list { get; set; }
        public string? nextPageCursor { get; set; }
    }

    public class BorrowContractInfoFixed
    {
        public string? annualRate { get; set; }
        public string? autoRepay { get; set; }              // "true" / "false"
        public string? borrowCurrency { get; set; }
        public string? borrowTime { get; set; }
        public string? interestPaid { get; set; }
        public string? loanId { get; set; }
        public string? orderId { get; set; }
        public string? repaymentTime { get; set; }
        public string? residualPenaltyInterest { get; set; }
        public string? residualPrincipal { get; set; }
        public int? status { get; set; }                    // 1 unrepaid; 2 fully repaid; 3 overdue
        public string? term { get; set; }                   // 7,14,30,90,180 (days)
    }

}
