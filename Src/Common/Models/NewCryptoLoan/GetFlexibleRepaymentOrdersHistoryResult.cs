using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bybit.net.api.Models.NewCryptoLoan
{
    public class GetFlexibleRepaymentOrdersHistoryResult
    {
        public List<FlexibleRepaymentOrderHistoryItem>? list { get; set; }
        public string? nextPageCursor { get; set; }
    }

    public class FlexibleRepaymentOrderHistoryItem
    {
        public string? loanCurrency { get; set; }
        public string? repayAmount { get; set; }
        public string? repayId { get; set; }
        public int? repayStatus { get; set; } // 1 success; 2 processing; 3 fail
        public long? repayTime { get; set; }
        public int? repayType { get; set; }   // 1 user; 2 liquidation; 5 delisting; 6 delay liquidation; 7 currency
    }

}
