using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bybit.net.api.Models.NewCryptoLoan
{
    public class GetRepaymentHistoryFixedResult
    {
        public List<RepaymentHistoryFixedItem>? list { get; set; }
        public string? nextPageCursor { get; set; }
    }

    public class RepaymentHistoryFixedItem
    {
        public List<RepaymentHistoryFixedDetail>? details { get; set; }
        public string? loanCurrency { get; set; }
        public long? repayAmount { get; set; }
        public string? repayId { get; set; }
        public int? repayStatus { get; set; } // 1 success, 2 processing, 3 fail
        public long? repayTime { get; set; }
        public int? repayType { get; set; }   // 1 user; 2 liquidation; 3 auto; 4 overdue; 5 delisting; 6 delay liquidation; 7 currency
    }

    public class RepaymentHistoryFixedDetail
    {
        public string? loanCurrency { get; set; }
        public long? repayAmount { get; set; }
        public string? loanId { get; set; }   // one repayment may involve multiple loan contracts
    }

}
