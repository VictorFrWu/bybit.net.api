using bybit.net.api.ApiServiceImp;
using bybit.net.api.Models;
using Xunit;

namespace bybit.api.test
{
    public class TradeServiceTest
    {
        BybitTradeService tradeService = new(apiKey: "8wYkmpLsMg10eNQyPm", apiSecret: "Ouxc34myDnXvei54XsBZgoQzfGxO4bkr2Zsj", true);
        #region Batch Order
        [Fact]
        public async Task Check_PlaceBatchOrderByDict()
        {
            Dictionary<string, object> dict1 = new() { { "symbol", "XRPUSDT" }, { "orderType", "Limit" }, { "side", "Buy" }, { "qty", "10" }, { "price", "0.6080" }, { "timeInForce", "GTC" } };
            Dictionary<string, object> dict2 = new() { { "symbol", "BLZUSDT" }, { "orderType", "Limit" }, { "side", "Buy" }, { "qty", "10" }, { "price", "0.6080" }, { "timeInForce", "GTC" } };
            List<Dictionary<string, object>> request = new() { dict1, dict2 };
            var orderInfo = await tradeService.PlaceBatchOrder(category: Category.LINEAR, request: request);
            Console.WriteLine(orderInfo);
        }

        [Fact]
        public async Task Check_PlaceBatchOrderByClass()
        {
            var order1 = new OrderRequest { Symbol = "XRPUSDT", OrderType = "Limit", Side = "Buy", Qty = "10", Price = "0.6080", TimeInForce = "GTC" };
            var order2 = new OrderRequest { Symbol = "BLZUSDT", OrderType = "Limit", Side = "Buy", Qty = "10", Price = "0.6080", TimeInForce = "GTC" };
            List<OrderRequest> request = new() { order1, order2 };
            var orderInfo = await tradeService.PlaceBatchOrder(category: Category.LINEAR, request: request);
            Console.WriteLine(orderInfo);
        }
        #endregion
    }
}