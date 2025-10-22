using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bybit.net.api.Models.RateLimit
{
    public class ApiRateLimitSetItem
    {
        public string? uids { get; set; }    // Multiple UIDs separated by commas
        public string? bizType { get; set; } // Business type
        public int? rate { get; set; }       // API rate limit per second
    }
}
