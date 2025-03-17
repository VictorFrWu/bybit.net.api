using bybit.net.api;
using bybit.net.api.ApiServiceImp;
using bybit.net.api.Models;
using bybit.net.api.Models.Account;
using bybit.net.api.Models.Market;
using bybit.net.api.Models.Trade;
using bybit.net.api.WebSocketStream;


//BybitMarketDataService market = new(url: BybitConstants.HTTP_TESTNET_URL, debugMode: true);
//var klineInfo = await market.GetMarketKline(Category.SPOT, "BTCUSDT", MarketInterval.OneMinute, limit: 3);
//Console.WriteLine(klineInfo);
//var klinePriceInfo = await market.GetMarKPricetKline(Category.LINEAR, "BTCUSDT", MarketInterval.OneMinute);
//Console.WriteLine(klinePriceInfo);

//var spotWebsocket = new BybitSpotWebSocket(true);
//spotWebsocket.OnMessageReceived(
//    (data) =>
//    {
//        Console.WriteLine(data);

//        return Task.CompletedTask;
//    }, CancellationToken.None);

//await spotWebsocket.ConnectAsync(new string[] { "orderbook.50.BTCUSDT" }, CancellationToken.None);


//var linearWebsocket = new BybitLinearWebSocket(true);
//linearWebsocket.OnMessageReceived(
//    (data) =>
//    {
//        Console.WriteLine(data);
//        return Task.CompletedTask;
//    }, CancellationToken.None);
//await linearWebsocket.ConnectAsync(new string[] { "publicTrade.BTCUSDT" }, CancellationToken.None);

//var privateWebsocket = new BybitPrivateWebsocket(apiKey: "xxxxxxxxxxxxxxxxxxxxx", apiSecret: "xxxxxxxxxxxxxxxxxxxxx", useTestNet: true, debugMode: true);
//privateWebsocket.OnMessageReceived(
//    (data) =>
//    {
//        Console.WriteLine(data);
//        return Task.CompletedTask;
//    }, CancellationToken.None);
//await privateWebsocket.ConnectAsync(new string[] { "order" }, CancellationToken.None);

//BybitTradeService tradeService = new(apiKey: "xxxxxxxxxxxxxx", apiSecret: "xxxxxxxxxxxxxxxxxxxxx");
//var orderInfo = await tradeService.PlaceOrder(category: Category.LINEAR, symbol: "BLZUSDT", side: Side.BUY, orderType: OrderType.MARKET, qty: "15", timeInForce: TimeInForce.GTC);
//Console.WriteLine(orderInfo);

//BybitPositionService positionService = new(apiKey: "xxxxxxxxxxxxxxxxxxxxx", apiSecret: "xxxxxxxxxxxxxxxxxxxxx", BybitConstants.HTTP_TESTNET_URL);
//var positionInfo = await positionService.GetPositionInfo(category: Category.LINEAR, symbol: "BLZUSDT");
//Console.WriteLine(positionInfo);

//BybitAccountService accountService = new(apiKey: "xxxxxxxxxxxxxxxxxxxxx", apiSecret: "xxxxxxxxxxxxxxxxxxxxx", url: BybitConstants.HTTP_TESTNET_URL);
//var accountInfo = await accountService.GetAccountBalance(accountType: AccountType.Unified, coin: "USDT");
//Console.WriteLine(accountInfo);

//Console.ReadLine();
