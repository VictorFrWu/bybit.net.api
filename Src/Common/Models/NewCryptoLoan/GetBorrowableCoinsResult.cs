using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bybit.net.api.Models.NewCryptoLoan
{
    public class GetBorrowableCoinsResult
    {
        public List<BorrowableCoinItem>? list { get; set; }
    }

    public class BorrowableCoinItem
    {
        public string? currency { get; set; }
        public bool? fixedBorrowable { get; set; }
        public int? fixedBorrowingAccuracy { get; set; }
        public bool? flexibleBorrowable { get; set; }
        public int? flexibleBorrowingAccuracy { get; set; }
        public string? maxBorrowingAmount { get; set; }
        public string? minFixedBorrowingAmount { get; set; }
        public string? minFlexibleBorrowingAmount { get; set; }
        public string? vipLevel { get; set; }
        public string? flexibleAnnualizedInterestRate { get; set; } // may be ""
        public string? annualizedInterestRate7D { get; set; }
        public string? annualizedInterestRate14D { get; set; }
        public string? annualizedInterestRate30D { get; set; }
        public string? annualizedInterestRate60D { get; set; }
        public string? annualizedInterestRate90D { get; set; }
        public string? annualizedInterestRate180D { get; set; }
    }

}
