// See https://aka.ms/new-console-template for more information
using bybit.net.api.ApiServiceImp;
using bybit.net.api.Models;
using bybit.net.api.Services;
using bybit.net.api.WebSocketStream;

Console.WriteLine("Hello, World!");

//BybitMarketDataService market = new BybitMarketDataService();
//var klineInfo = await market.GetMarketKline("spot", "BTCUSDT", "1");
//Console.WriteLine(klineInfo);

//var websocket = new BybitSpotWebSocket();
//websocket.OnMessageReceived(
//    (data) =>
//    {
//        Console.WriteLine(data);

//        return Task.CompletedTask;
//    }, CancellationToken.None);

//await websocket.ConnectAsync(new string[] { "orderbook.50.BTCUSDT" }, CancellationToken.None);


//BybitMarketDataService market = new BybitMarketDataService();
//var klineInfo = await market.GetMarKPricetKline("linear", "BTCUSDT", "1");
//Console.WriteLine(klineInfo);

//var websocket = new BybitLinearWebSocket();
//websocket.OnMessageReceived(
//    (data) =>
//    {
//        Console.WriteLine(data);

//        return Task.CompletedTask;
//    }, CancellationToken.None);

//await websocket.ConnectAsync(new string[] { "publicTrade.BTCUSDT" }, CancellationToken.None);

//var websocket = new BybitPrivateWebsocket(apiKey: "8wYkmpLsMg10eNQyPm", apiSecret: "Ouxc34myDnXvei54XsBZgoQzfGxO4bkr2Zsj");
//websocket.OnMessageReceived(
//    (data) =>
//    {
//        Console.WriteLine(data);

//        return Task.CompletedTask;
//    }, CancellationToken.None);

//await websocket.ConnectAsync(new string[] { "order" }, CancellationToken.None);

//BybitTradeService tradeService = new BybitTradeService(apiKey: "8wYkmpLsMg10eNQyPm", apiSecret: "Ouxc34myDnXvei54XsBZgoQzfGxO4bkr2Zsj");
//var orderInfo = await tradeService.PlaceOrder(category: Category.LINEAR, symbol: "BLZUSDT", side: Side.BUY, orderType: OrderType.MARKET, qty: "15", timeInForce: TimeInForce.GTC);
//Console.WriteLine(orderInfo);

//BybitAccountService accountService = new BybitAccountService(apiKey: "8wYkmpLsMg10eNQyPm", apiSecret: "Ouxc34myDnXvei54XsBZgoQzfGxO4bkr2Zsj");
//var accountInfo = await accountService.GetAccountBalance(accountType: AccountType.Unified);
//Console.WriteLine(accountInfo);

BybitPositionService positionService = new BybitPositionService(apiKey: "8wYkmpLsMg10eNQyPm", apiSecret: "Ouxc34myDnXvei54XsBZgoQzfGxO4bkr2Zsj");
var positionInfo = await positionService.GetPositionInfo(category: Category.LINEAR, symbol: "BLZUSDT");
Console.WriteLine(positionInfo);
Console.ReadLine();
