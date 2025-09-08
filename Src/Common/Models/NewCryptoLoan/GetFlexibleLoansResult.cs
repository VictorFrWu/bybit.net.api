using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bybit.net.api.Models.NewCryptoLoan
{
    public class GetFlexibleLoansResult
    {
        public List<FlexibleOngoingLoanItem>? list { get; set; }
    }

    public class FlexibleOngoingLoanItem
    {
        public string? hourlyInterestRate { get; set; }
        public string? loanCurrency { get; set; }
        public string? totalDebt { get; set; }
    }

}
