# bybit.net.api

The Official DotNet API connector for Bybit's HTTP and WebSocket APIs.

## Table of Contents

- [About](#about)
- [Development](#development)
- [Installation](#installation)
- [Usage](#usage)
- [Contact](#contact)
- [Contributors](#contributors)
- [Donations](#donations)

## About
Bybit.Net.Api provides an official, robust, and high-performance DotNet connector to Bybit's trading APIs. Initially conceptualized by esteemed DotNet developer Victor, this module is now maintained by Bybit's in-house DotNet experts. Your contributions are most welcome!

## Development
Bybit.Net.Api is under active development with the latest features and updates from Bybit's API implemented promptly. The module utilizes minimal external libraries to provide a lightweight and efficient experience. If you've made enhancements or fixed bugs, please submit a pull request.

## Installation
Ensure you have DotNet 11 or higher. You can include Bybit.Net.Api in your project using Maven or Gradle.

Maven Example
```DotNet
bybit.net.api.1.0.0.nupkg
```

## Usage

### Http Examples
- Place Single Order
```DotNet
BybitTradeService tradeService = new BybitTradeService(apiKey: "xxxxxxxxxxx", apiSecret: "xxxxxxxxxxxxxxxx");
var orderInfo = await tradeService.PlaceOrder(category: Category.LINEAR, symbol: "BLZUSDT", side: Side.BUY, orderType: OrderType.MARKET, qty: "15", timeInForce: TimeInForce.GTC);
Console.WriteLine(orderInfo);
```

- Market Kline
```DotNet
BybitMarketDataService market = new BybitMarketDataService();
var klineInfo = await market.GetMarketKline("spot", "BTCUSDT", "1");
Console.WriteLine(klineInfo);
```

- Account Wallet
```DotNet
BybitAccountService accountService = new BybitAccountService(apiKey: "xxxxxxxx", apiSecret: "xxxxxxxxxxxxxxx");
var accountInfo = await accountService.GetAccountBalance(accountType: AccountType.Unified);
Console.WriteLine(accountInfo);
```
- Position Info
```DotNet
BybitPositionService positionService = new BybitPositionService(apiKey: "xxxxxx", apiSecret: "xxxxxxxxxxxxxxxxx");
var positionInfo = await positionService.GetPositionInfo(category: Category.LINEAR, symbol: "BLZUSDT");
Console.WriteLine(positionInfo);
```

### Websocket public channel
- Trade Subscribe
```DotNet
var websocket = new BybitLinearWebSocket();
websocket.OnMessageReceived(
    (data) =>
    {
        Console.WriteLine(data);

        return Task.CompletedTask;
    }, CancellationToken.None);

await websocket.ConnectAsync(new string[] { "publicTrade.BTCUSDT" }, CancellationToken.None);
```

### Websocket private channel
- Order Subscribe
```DotNet
var websocket = new BybitPrivateWebsocket(apiKey: "xxxxxxxxx", apiSecret: "xxxxxxxxxxxxxxxxxx");
websocket.OnMessageReceived(
    (data) =>
    {
        Console.WriteLine(data);

        return Task.CompletedTask;
    }, CancellationToken.None);

await websocket.ConnectAsync(new string[] { "order" }, CancellationToken.None);
```
## Contact
For support, join our DotNet Bybit API community on DotNetBybitAPI Telegram.

## Contributors
List of other contributors
<table>
  <tr>
    <td align="center">
        <a href="https://github.com/wuhewuhe">
            <img src="https://avatars.githubusercontent.com/u/32245754?v=4" width="100px;" alt=""/>
            <br />
            <sub>   
                <b>Victor</b>
            </sub>
        </a>
        <br />
        <a href="https://github.com/wuhewuhe/bybit-DotNet-api/commits?author=wuhewuhe" title="Code">💻</a>
        <a href="https://github.com/wuhewuhe/bybit-DotNet-api/commits?author=wuhewuhe" title="Documentation">📖</a>
    </td>
  </tr>
</table>

## Donations
Your donations keep our development active and our community growing. Donate to YOUR_CRYPTO_ADDRESS.

Note: Replace placeholders (like YOUR_API_KEY, links, or other details) with the actual information. You can also customize this template to better fit the actual state and details of your DotNet API.