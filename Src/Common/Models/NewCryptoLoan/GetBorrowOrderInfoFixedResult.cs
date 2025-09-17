using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bybit.net.api.Models.NewCryptoLoan
{
    public class GetBorrowOrderInfoFixedResult
    {
        public List<BorrowOrderInfoFixed>? list { get; set; }
        public string? nextPageCursor { get; set; }
    }

    public class BorrowOrderInfoFixed
    {
        public string? annualRate { get; set; }
        public long? orderId { get; set; }
        public string? orderTime { get; set; }
        public string? filledQty { get; set; }
        public string? orderQty { get; set; }
        public string? orderCurrency { get; set; }
        public int? state { get; set; } // 1 matching; 2 partially filled and cancelled; 3 fully filled; 4 cancelled; 5 fail
        public int? term { get; set; }  // 7,14,30,90,180
    }

}
