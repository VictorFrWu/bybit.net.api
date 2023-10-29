using bybit.net.api.ApiServiceImp;
using bybit.net.api.Models;
using bybit.net.api.Models.Trade;
using Newtonsoft.Json;
using Xunit;

namespace bybit.api.test
{
    public class TradeServiceTest
    {
        readonly BybitTradeService TradeService = new(apiKey: "YOUR_API_KEY", apiSecret: "YOUR_API_SECRET", true);
        #region Batch Order
        [Fact]
        public async Task Check_PlaceBatchOrderByDict()
        {
            Dictionary<string, object> dict1 = new() { { "symbol", "XRPUSDT" }, { "orderType", "Limit" }, { "side", "Buy" }, { "qty", "10" }, { "price", "0.6080" }, { "timeInForce", "GTC" } };
            Dictionary<string, object> dict2 = new() { { "symbol", "BLZUSDT" }, { "orderType", "Limit" }, { "side", "Buy" }, { "qty", "10" }, { "price", "0.6080" }, { "timeInForce", "GTC" } };
            List<Dictionary<string, object>> request = new() { dict1, dict2 };
            var orderInfoString = await TradeService.PlaceBatchOrder(category: Category.LINEAR, request: request);
            if (!string.IsNullOrEmpty(orderInfoString))
            {
                Console.WriteLine(orderInfoString);
                OrderResult? orderInfo = JsonConvert.DeserializeObject<OrderResult>(orderInfoString);
                Assert.Equal(0, orderInfo?.RetCode);
                Assert.Equal("OK", orderInfo?.RetMsg);
                Assert.NotNull(orderInfo?.Result?.OrderId);
            }
        }

        [Fact]
        public async Task Check_PlaceBatchOrderByClass()
        {
            var order1 = new OrderRequest { Symbol = "XRPUSDT", OrderType = "Limit", Side = "Buy", Qty = "10", Price = "0.6080", TimeInForce = "GTC" };
            var order2 = new OrderRequest { Symbol = "BLZUSDT", OrderType = "Limit", Side = "Buy", Qty = "10", Price = "0.6080", TimeInForce = "GTC" };
            List<OrderRequest> request = new() { order1, order2 };
            var orderInfoString = await TradeService.PlaceBatchOrder(category: Category.LINEAR, request: request);
            if (!string.IsNullOrEmpty(orderInfoString))
            {
                Console.WriteLine(orderInfoString);
                OrderResult? orderInfo = JsonConvert.DeserializeObject<OrderResult>(orderInfoString);
                Assert.Equal(0, orderInfo?.RetCode);
                Assert.Equal("OK", orderInfo?.RetMsg);
                Assert.NotNull(orderInfo?.Result?.OrderId);
            }
        }

        [Fact]
        public async Task Check_PlaceBatchOrderByStruct()
        {
            var order1 = new OrderRequest { Symbol = "XRPUSDT", OrderType = OrderType.LIMIT.Value, Side = Side.BUY.Value, Qty = "10", Price = "0.6080", TimeInForce = TimeInForce.GTC.Value };
            var order2 = new OrderRequest { Symbol = "BLZUSDT", OrderType = OrderType.LIMIT.Value, Side = Side.BUY.Value, Qty = "10", Price = "0.6080", TimeInForce = TimeInForce.GTC.Value };
            List<OrderRequest> request = new() { order1, order2 };
            var orderInfoString = await TradeService.PlaceBatchOrder(category: Category.LINEAR, request: request);
            if (!string.IsNullOrEmpty(orderInfoString))
            {
                Console.WriteLine(orderInfoString);
                OrderResult? orderInfo = JsonConvert.DeserializeObject<OrderResult>(orderInfoString);
                Assert.Equal(0, orderInfo?.RetCode);
                Assert.Equal("OK", orderInfo?.RetMsg);
                Assert.NotNull(orderInfo?.Result?.OrderId);
            }
        }
        #endregion
    }
}