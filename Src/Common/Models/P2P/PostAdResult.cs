using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bybit.net.api.Models.P2P
{
    public class PostAdResult
    {
        public string? itemId { get; set; }
        public string? securityRiskToken { get; set; }
        public string? riskTokenType { get; set; }
        public string? riskVersion { get; set; }
        public bool? needSecurityRisk { get; set; }
    }

}
