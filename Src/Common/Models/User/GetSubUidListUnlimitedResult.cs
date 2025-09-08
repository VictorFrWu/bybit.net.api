using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bybit.net.api.Models.User
{
    public class GetSubUidListUnlimitedResult
    {
        public List<SubMember>? subMembers { get; set; }
        public string? nextCursor { get; set; } // "0" => no more pages
    }
}
