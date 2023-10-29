using bybit.net.api.Models.Trade;
using Xunit;

namespace bybit.api.test.Models
{
    public class OrderType_Tests
    {
        [Fact]
        public void ToString_Matches_Value()
        {
            var model = OrderType.LIMIT;

            Assert.Equal(model.Value.ToString(), model.ToString());
        }
    }
}
