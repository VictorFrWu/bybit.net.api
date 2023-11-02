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
            var orderInfoString = await TradeService.PlaceBatchOrder(category: Category.LINEAR, request: new List<OrderRequest> { order1, order2 });
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
            var request = new List<OrderRequest> { order1, order2 };
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
        public async Task Check_AmendOrder()
        {
            var orderInfoString = await TradeService.AmendOrder(orderId: "1523347543495541248", category: Category.LINEAR, symbol: "XRPUSDT", price: "0.5", qty: "15");
            if (!string.IsNullOrEmpty(orderInfoString))
            {
                Console.WriteLine(orderInfoString);
                OrderResult? orderInfo = JsonConvert.DeserializeObject<OrderResult>(orderInfoString);
                Assert.Equal(0, orderInfo?.RetCode);
                Assert.Equal("OK", orderInfo?.RetMsg);
            }
        }

        [Fact]
        public async Task Check_AmendBatchOrder()
        {
            var order1 = new OrderRequest { Symbol = "XRPUSDT", OrderId = "xxxxxxxxxx", Qty = "10", Price = "0.6080" };
            var order2 = new OrderRequest { Symbol = "BLZUSDT", OrderId = "xxxxxxxxxx", Qty = "15", Price = "0.6090" };
            var orderInfoString = await TradeService.AmendBatchOrder(category: Category.LINEAR, request: new List<OrderRequest> { order1, order2 });
            if (!string.IsNullOrEmpty(orderInfoString))
            {
                Console.WriteLine(orderInfoString);
                OrderResult? orderInfo = JsonConvert.DeserializeObject<OrderResult>(orderInfoString);
                Assert.Equal(0, orderInfo?.RetCode);
                Assert.Equal("OK", orderInfo?.RetMsg);
            }
        }

        [Fact]
        public async Task Check_CancelOrder()
        {
            var orderInfoString = await TradeService.CancelOrder(orderId: "1523347543495541248", category: Category.SPOT, symbol: "XRPUSDT");
            if (!string.IsNullOrEmpty(orderInfoString))
            {
                Console.WriteLine(orderInfoString);
                OrderResult? orderInfo = JsonConvert.DeserializeObject<OrderResult>(orderInfoString);
                Assert.Equal(0, orderInfo?.RetCode);
                Assert.Equal("OK", orderInfo?.RetMsg);
            }
        }

        [Fact]
        public async Task Check_CancelBatchOrder()
        {
            var order1 = new OrderRequest { Symbol = "BTC-10FEB23-24000-C", OrderLinkId = "9b381bb1-401" };
            var order2 = new OrderRequest { Symbol = "BTC-10FEB23-24000-C", OrderLinkId = "82ee86dd-001" };
            var orderInfoString = await TradeService.CancelBatchOrder(category: Category.LINEAR, request: new List<OrderRequest> { order1, order2 });
            if (!string.IsNullOrEmpty(orderInfoString))
            {
                Console.WriteLine(orderInfoString);
                OrderResult? orderInfo = JsonConvert.DeserializeObject<OrderResult>(orderInfoString);
                Assert.Equal(0, orderInfo?.RetCode);
                Assert.Equal("OK", orderInfo?.RetMsg);
            }
        }
        #endregion
    }
}