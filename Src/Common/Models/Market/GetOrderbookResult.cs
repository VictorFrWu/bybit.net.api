using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bybit.net.api.Models.Market
{
    public class GetOrderbookResult
    {
        public string? s { get; set; }
        public List<List<string>>? b { get; set; } // [price, size]
        public List<List<string>>? a { get; set; } // [price, size]
        public long? ts { get; set; }
        public long? u { get; set; }
        public long? seq { get; set; }
        public long? cts { get; set; }
    }
}
