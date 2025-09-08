using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bybit.net.api.Models.Asset
{
    public class ConfirmQuoteResult
    {
        public string? quoteTxId { get; set; }
        public string? exchangeStatus { get; set; } // init, processing, success, failure
    }

}
