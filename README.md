# Bybit Open API Connector .Net6

![[Nuget](https://img.shields.io/nuget/v/bybit.net.api)](https://www.nuget.org/packages/bybit.net.api) ![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://github.com/wuhewuhe/bybit.net.api/blob/main/LICENSE) ![contributions welcome](https://img.shields.io/badge/contributions-welcome-brightgreen.svg?style=flat)

## Table of Contents

- [About](#about)
- [Development](#development)
- [Installation](#installation)
- [Usage](#usage)
- [Contact](#contact)
- [Contributors](#contributors)
- [Donations](#donations)

## About
**Bybit.Net.Api** offers an official, powerful, and efficient .NET connector to the  [Bybit public Trading API](https://bybit-exchange.github.io/docs/v5/intro)

Dive into a plethora of functionalities:
- Market Data Retrieval
- Trade Execution
- Position Management
- Account and Asset Info Retrieval
- User Management
- Public Websocket Streaming
- Private Websocket Streaming

This initiative, originated by the renowned .NET developer Victor, now flourishes under the meticulous care of Bybit's dedicated team of in-house .NET professionals. 
Your contributions are warmly welcomed and appreciated!

## Development
**Bybit.Net.Api** constantly evolves, keeping pace with the freshest features from Bybit's API. Crafted for efficiency, the library maintains a slim profile by minimizing external dependencies. If you've broadened its horizons or ironed out bugs, we eagerly await your pull request.

## Installation
Ensure you're using .NET 6 or newer. This SDK depends on Microsoft.Extensions.Logging 7.0.0 and Newtonsoft 13.0.3.
Dotnet CLI
```bash
dotnet add package bybit.net.api
```

Nuget tool
```DotNet
NuGet\Install-Package bybit.net.api
```

Package reference
```DotNet
<PackageReference Include="bybit.net.api"/>
```
## Usage

### RESTful APIs
- Market Kline
```DotNet
BybitMarketDataService market = new BybitMarketDataService();
var klineInfo = await market.GetMarketKline("spot", "BTCUSDT", "1");
Console.WriteLine(klineInfo);
```

### Authentication - RESTful APIs
- Place Single Order
```DotNet
BybitTradeService tradeService = new BybitTradeService(apiKey: "xxxxxxxxxxx", apiSecret: "xxxxxxxxxxxxxxxx");
var orderInfo = await tradeService.PlaceOrder(category: Category.LINEAR, symbol: "BLZUSDT", side: Side.BUY, orderType: OrderType.MARKET, qty: "15", timeInForce: TimeInForce.GTC);
Console.WriteLine(orderInfo);
```

- Account Wallet
```DotNet
BybitAccountService accountService = new BybitAccountService(apiKey: "xxxxxxxx", apiSecret: "xxxxxxxxxxxxxxx");
var accountInfo = await accountService.GetAccountBalance(accountType: AccountType.Unified);
Console.WriteLine(accountInfo);
```
- Position Info
```DotNet
BybitPositionService positionService = new BybitPositionService(apiKey: "xxxxxxxxxxxxxxxxxxxx", apiSecret: "xxxxxxxxxxxxxxxxx");
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
For support, join our Bybit API community on [Telegram](https://t.me/Bybitapi).

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
        <a href="https://github.com/wuhewuhe/bybit-java-api/commits?author=wuhewuhe" title="Code">💻</a>
        <a href="https://github.com/wuhewuhe/bybit-java-api/commits?author=wuhewuhe" title="Documentation">📖</a>
    </td>
    <td align="center">
        <a href="https://github.com/Doom-Prince">
            <img src="https://avatars.githubusercontent.com/u/124635036?v=4" width="100px;" alt=""/>
            <br />
            <sub>   
                <b>Doom</b>
            </sub>
        </a>
        <br />
        <a href="https://github.com/wuhewuhe/bybit-java-api/commits?author=Doom-Prince" title="Code">💻</a>
        <a href="https://github.com/wuhewuhe/bybit-java-api/commits?author=Doom-Prince" title="Documentation">📖</a>
    </td>
  </tr>
</table>

## Donations
Your donations keep our development active and our community growing. Donate USDT to our [ERC20 Wallet Address](0x238bbb45af1254e2fd76564c9b56042c452f3d6e).

Note: Replace placeholders (like YOUR_API_KEY, links, or other details) with the actual information. You can also customize this template to better fit the actual state and details of your DotNet API.