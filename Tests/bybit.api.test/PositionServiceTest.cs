using bybit.net.api.Models;
using Xunit;
using bybit.net.api.ApiServiceImp;

namespace bybit.api.test
{
    public class PositionServiceTest
    {
        readonly BybitPositionService PositionService = new(apiKey: "8wYkmpLsMg10eNQyPm", apiSecret: "Ouxc34myDnXvei54XsBZgoQzfGxO4bkr2Zsj", true);
        #region Poistion Confirm new risk limit
        [Fact]
        public async Task Check_ConfirmPositionNewRiskLimit()
        {
            var positionInfoString = await PositionService.ConfirmPositionRiskLimit(category: Category.LINEAR, symbol:"BTCUSDT");
            await Console.Out.WriteLineAsync(positionInfoString);
        }
        #endregion
    }
}
