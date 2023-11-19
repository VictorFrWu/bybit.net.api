using bybit.net.api.Models;
using Xunit;
using bybit.net.api.ApiServiceImp;
using bybit.net.api;

namespace bybit.api.test
{
    public class PositionServiceTest
    {
        readonly BybitPositionService PositionService = new(apiKey: "8wYkmpLsMg10eNQyPm", apiSecret: "Ouxc34myDnXvei54XsBZgoQzfGxO4bkr2Zsj", url:BybitConstants.HTTP_TESTNET_URL);
        #region Poistion GetPositionList
        [Fact]
        public async Task Check_ConfirmPositionInfo()
        {
            var inversePositionInfoString = await PositionService.GetPositionInfo(category: Category.INVERSE, symbol: "BTCUSD");
            await Console.Out.WriteLineAsync(inversePositionInfoString);
        }
        #endregion
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
