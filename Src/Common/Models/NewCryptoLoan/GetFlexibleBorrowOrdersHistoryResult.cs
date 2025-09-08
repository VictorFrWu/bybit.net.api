using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bybit.net.api.Models.NewCryptoLoan
{
    public class GetFlexibleBorrowOrdersHistoryResult
    {
        public List<FlexibleBorrowOrderHistoryItem>? list { get; set; }
        public string? nextPageCursor { get; set; }
    }

    public class FlexibleBorrowOrderHistoryItem
    {
        public long? borrowTime { get; set; }
        public string? initialLoanAmount { get; set; }
        public string? loanCurrency { get; set; }
        public string? orderId { get; set; }
        public int? status { get; set; } // 1 success; 2 processing; 3 fail
    }

}
