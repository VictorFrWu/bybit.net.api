using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bybit.net.api.Models.Market
{
    public class GetRiskLimitResult
    {
        public string? category { get; set; }
        public List<RiskLimit>? list { get; set; }
        public string? nextPageCursor { get; set; }
    }

    public class RiskLimit
    {
        public int? id { get; set; }
        public string? symbol { get; set; }
        public string? riskLimitValue { get; set; }
        public string? maintenanceMargin { get; set; }
        public string? initialMargin { get; set; }
        public int? isLowestRisk { get; set; } // 1 true, 0 false
        public string? maxLeverage { get; set; }
        public string? mmDeduction { get; set; }
    }

}
