using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bybit.net.api.Models.Account.Response
{
    public class GetContractTransactionLogClassicResult
    {
        public List<ContractTransactionLogClassic>? list { get; set; }
        public string? nextPageCursor { get; set; }
    }

    public class ContractTransactionLogClassic
    {
        public string? id { get; set; }
        public string? symbol { get; set; }
        public string? category { get; set; }
        public string? side { get; set; }                 // Buy, Sell, None
        public string? transactionTime { get; set; }      // ms
        public string? type { get; set; }
        public string? qty { get; set; }
        public string? size { get; set; }                 // signed
        public string? currency { get; set; }
        public string? tradePrice { get; set; }
        public string? funding { get; set; }              // + deduct, - receive
        public string? fee { get; set; }                  // + expense, - rebate
        public string? cashFlow { get; set; }
        public string? change { get; set; }               // cashFlow - funding - fee
        public string? cashBalance { get; set; }
        public string? feeRate { get; set; }              // depends on type/side
        public string? bonusChange { get; set; }
        public string? tradeId { get; set; }
        public string? orderId { get; set; }
        public string? orderLinkId { get; set; }
    }

}
