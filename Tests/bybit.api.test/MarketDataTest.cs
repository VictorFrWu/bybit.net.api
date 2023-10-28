using bybit.net.api.ApiServiceImp;
using Moq;
using Moq.Protected;
using System.Net;
using Xunit;

namespace bybit.api.test
{
    public class MarketDataTest
    {
        #region CheckServerTime
        [Fact]
        public async Task CheckServerTime_ResponseAsync()
        {
            var responseContent = "{\"timeSecond\":1499827319559}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/v5/market/time", HttpMethod.Get)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });

            BybitMarketDataService market = new(
                new HttpClient(mockMessageHandler.Object));

            var result = await market.CheckServerTime();

            Assert.Equal(responseContent, result);
        }
        #endregion
    }
}