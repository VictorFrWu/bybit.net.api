# Bybit Open API Connector .Net6

[![Nuget](https://img.shields.io/nuget/v/bybit.net.api)](https://www.nuget.org/packages/bybit.net.api) [![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://github.com/wuhewuhe/bybit.net.api/blob/main/LICENSE) [![Contributor Victor](https://img.shields.io/badge/contributor-Victor-blue.svg)](https://github.com/wuhewuhe/bybit-java-api)

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
- Public Websocket Streaming
- Private Websocket Streaming
- Market Data Retrieval
- Trade Execution
- Position Management
- Account and Asset Info Retrieval
- User Management
- Upgrade History
- Spot Margin UTA & Classical Service
- Broker Earning Data

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
By default is bybit Mainnet, if you want to test in Bybit testnet, please add a parameter **useTestnet: true** when initiate service instance

Note: Replace placeholders (like YOUR_API_KEY, links, or other details) with the actual information. You can also customize this template to better fit the actual state and details of your DotNet API.
### RESTful APIs
- Market Kline
```DotNet
BybitMarketDataService market = new();
var klineInfo = await market.GetMarketKline(Category.SPOT, "BTCUSDT", MarketInterval.OneMinute);
Console.WriteLine(klineInfo);
```

### Authentication - RESTful APIs
- Place Single Order
```DotNet
BybitTradeService tradeService = new(apiKey: "xxxxxxxxxxxxxx", apiSecret: "xxxxxxxxxxxxxxxxxxxxx");
var orderInfo = await tradeService.PlaceOrder(category: Category.LINEAR, symbol: "BLZUSDT", side: Side.BUY, orderType: OrderType.MARKET, qty: "15", timeInForce: TimeInForce.GTC);
Console.WriteLine(orderInfo);
```

- Account Wallet
```DotNet
BybitAccountService accountService = new(apiKey: "xxxxxxxxxxxxxx", apiSecret: "xxxxxxxxxxxxxxxxxxxxx");
var accountInfo = await accountService.GetAccountBalance(accountType: AccountType.Unified);
Console.WriteLine(accountInfo);
```
- Position Info
```DotNet
BybitPositionService positionService = new(apiKey: "xxxxxxxxxxxxxx", apiSecret: "xxxxxxxxxxxxxxxxxxxxx", true);
var positionInfo = await positionService.GetPositionInfo(category: Category.LINEAR, symbol: "BLZUSDT");
Console.WriteLine(positionInfo);
```

### Websocket public channel
- Trade Subscribe
```DotNet
var linearWebsocket = new BybitLinearWebSocket(true);
linearWebsocket.OnMessageReceived(
    (data) =>
    {
        Console.WriteLine(data);
        return Task.CompletedTask;
    }, CancellationToken.None);
await linearWebsocket.ConnectAsync(new string[] { "publicTrade.BTCUSDT" }, CancellationToken.None);
```

### Websocket private channel
- Order Subscribe
```DotNet
var privateWebsocket = new BybitPrivateWebsocket(apiKey: "xxxxxxxxxxxxxx", apiSecret: "xxxxxxxxxxxxxxxxxxxxx");
privateWebsocket.OnMessageReceived(
    (data) =>
    {
        Console.WriteLine(data);
        return Task.CompletedTask;
    }, CancellationToken.None);
await privateWebsocket.ConnectAsync(new string[] { "order" }, CancellationToken.None);
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
        <a href="https://github.com/wuhewuhe/bybit.net.api/commits?author=wuhewuhe" title="Code">💻</a>
        <a href="https://github.com/wuhewuhe/bybit.net.api/commits?author=wuhewuhe" title="Documentation">📖</a>
    </td>
  </tr>
</table>

## Donations
Your donations keep our development active and our community growing. Donate USDT to our [ERC20 Wallet Address](0x238bbb45af1254e2fd76564c9b56042c452f3d6e).

