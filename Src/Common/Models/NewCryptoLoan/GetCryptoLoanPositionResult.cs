using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bybit.net.api.Models.NewCryptoLoan
{
    public class GetCryptoLoanPositionResult
    {
        public List<CryptoLoanBorrowItem>? borrowList { get; set; }
        public List<CryptoLoanCollateralItem>? collateralList { get; set; }
        public string? ltv { get; set; }
        public List<CryptoLoanSupplyItem>? supplyList { get; set; }
        public string? totalCollateral { get; set; }
        public string? totalDebt { get; set; }
        public string? totalSupply { get; set; }
    }

    public class CryptoLoanBorrowItem
    {
        public string? fixedTotalDebt { get; set; }
        public string? fixedTotalDebtUSD { get; set; }
        public string? flexibleHourlyInterestRate { get; set; }
        public string? flexibleTotalDebt { get; set; }
        public string? flexibleTotalDebtUSD { get; set; }
        public string? loanCurrency { get; set; }
    }

    public class CryptoLoanCollateralItem
    {
        public string? amount { get; set; }
        public string? amountUSD { get; set; }
        public string? currency { get; set; }
    }

    public class CryptoLoanSupplyItem
    {
        public string? amount { get; set; }
        public string? amountUSD { get; set; }
        public string? currency { get; set; }
    }

}
