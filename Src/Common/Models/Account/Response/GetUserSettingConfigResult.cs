using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bybit.net.api.Models.Account.Response
{
    public class GetUserSettingConfigResult
    {
        public List<UserSettingConfig>? result { get; set; }
    }

    public class UserSettingConfig
    {
        public bool? lpaSpot { get; set; }
        public bool? lpaPerp { get; set; }
    }

}
