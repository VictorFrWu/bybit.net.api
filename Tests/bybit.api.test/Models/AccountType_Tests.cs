using bybit.net.api.Models.Account;
using Xunit;

namespace bybit.api.test.Models
{
    public class AccountType_Tests
    {
        [Fact]
        public void ToString_Matches_Value()
        {
            var model = AccountType.Spot;

            Assert.Equal(model.Value.ToString(), model.ToString());
        }
    }
}
