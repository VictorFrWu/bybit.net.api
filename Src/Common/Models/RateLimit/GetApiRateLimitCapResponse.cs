using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bybit.net.api.Models.RateLimit
{
    public class GetApiRateLimitCapResponse
    {
        public List<ApiRateLimitCapItem>? list { get; set; }
    }

    public class ApiRateLimitCapItem
    {
        public string? bizType { get; set; }  // Business type
        public int? totalRate { get; set; }   // Total usage across master + subs
        public int? insCap { get; set; }      // Institutional-level cap per second
        public int? uidCap { get; set; }      // UID-level cap per second
    }
}
