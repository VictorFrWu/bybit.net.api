using bybit.net.api.Models.Trade;
using Xunit;

namespace bybit.api.test.Models
{
    public class Side_Tests
    {
        [Fact]
        public void ToString_Matches_Value()
        {
            var model = Side.BUY;

            Assert.Equal(model.Value.ToString(), model.ToString());
        }
    }
}
