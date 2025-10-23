using bybit.net.api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bybit.net.api.ApiServiceImp
{
    public class BybitNewCryptoLoanService : BybitApiService
    {
        public BybitNewCryptoLoanService(string apiKey, string apiSecret, string? url = null, string recvWindow = BybitConstants.DEFAULT_REC_WINDOW, bool debugMode = false)
        : this(httpClient: new HttpClient(), apiKey: apiKey, apiSecret: apiSecret, url: url, recvWindow: recvWindow, debugMode: debugMode)
        {
        }

        public BybitNewCryptoLoanService(HttpClient httpClient, string apiKey, string apiSecret, string? url = null, string recvWindow = BybitConstants.DEFAULT_REC_WINDOW, bool debugMode = false)
            : base(httpClient: httpClient, apiKey: apiKey, apiSecret: apiSecret, url: url, recvWindow: recvWindow, debugMode: debugMode)
        {
        }

        private const string GET_BORROWABLE_COINS = "/v5/crypto-loan-common/loanable-data";

        /// <summary>
        /// Get Borrowable Coins
        /// Public endpoint. Lists borrowable coins and limits.
        /// </summary>
        /// <param name="vipLevel">VIP0..VIP5, VIP99, PRO1..PRO6</param>
        /// <param name="currency">Coin, uppercase</param>
        /// <returns></returns>
        public async Task<string?> GetBorrowableCoins(string? vipLevel = null, string? currency = null)
        {
            var query = new Dictionary<string, object>();
            BybitParametersUtils.AddOptionalParameters(query,
                ("vipLevel", vipLevel),
                ("currency", currency)
            );

            var result = await this.SendPublicAsync<string>(GET_BORROWABLE_COINS, HttpMethod.Get, query: query);
            return result;
        }

        private const string GET_COLLATERAL_COINS = "/v5/crypto-loan-common/collateral-data";

        /// <summary>
        /// Get Collateral Coins
        /// Public. Collateral ratios and liquidation priority.
        /// </summary>
        /// <param name="currency">Optional coin, uppercase</param>
        /// <returns></returns>
        public async Task<string?> GetCollateralCoins(string? currency = null)
        {
            var query = new Dictionary<string, object>();
            BybitParametersUtils.AddOptionalParameters(query, ("currency", currency));

            var result = await this.SendPublicAsync<string>(GET_COLLATERAL_COINS, HttpMethod.Get, query: query);
            return result;
        }

        private const string GET_MAX_ALLOWED_COLLATERAL_REDUCTION_AMOUNT = "/v5/crypto-loan-common/max-collateral-amount";

        /// <summary>
        /// Get Max. Allowed Collateral Reduction Amount
        /// Retrieve the maximum redeemable amount of your collateral asset based on LTV. Auth required.
        /// </summary>
        /// <param name="currency">Collateral coin</param>
        /// <returns></returns>
        public async Task<string?> GetMaxAllowedCollateralReductionAmount(string currency)
        {
            var query = new Dictionary<string, object> { { "currency", currency } };

            var result = await this.SendSignedAsync<string>(
                GET_MAX_ALLOWED_COLLATERAL_REDUCTION_AMOUNT,
                HttpMethod.Get,
                query: query
            );
            return result;
        }

        private const string ADJUST_COLLATERAL_AMOUNT = "/v5/crypto-loan-common/adjust-ltv";

        /// <summary>
        /// Adjust Collateral Amount
        /// Increase or reduce collateral. Funds are moved to/from Funding wallet.
        /// </summary>
        /// <param name="currency">Collateral coin</param>
        /// <param name="amount">Adjustment amount</param>
        /// <param name="direction">"0": add collateral; "1": reduce collateral</param>
        /// <returns></returns>
        public async Task<string?> AdjustCollateralAmount(string currency, string amount, string direction)
        {
            var body = new Dictionary<string, object>
            {
                { "currency", currency },
                { "amount", amount },
                { "direction", direction }
            };

            var result = await this.SendSignedAsync<string>(ADJUST_COLLATERAL_AMOUNT, HttpMethod.Post, query: body);
            return result;
        }

        private const string GET_COLLATERAL_ADJUSTMENT_HISTORY = "/v5/crypto-loan-common/adjustment-history";

        /// <summary>
        /// Get Collateral Adjustment History
        /// Query LTV adjustment history. Auth required.
        /// </summary>
        /// <param name="adjustId">Collateral adjustment transaction ID</param>
        /// <param name="collateralCurrency">Collateral coin</param>
        /// <param name="limit">[1,100], default 10</param>
        /// <param name="cursor">pagination cursor</param>
        /// <returns></returns>
        public async Task<string?> GetCollateralAdjustmentHistory(
            string? adjustId = null,
            string? collateralCurrency = null,
            string? limit = null,
            string? cursor = null)
        {
            var query = new Dictionary<string, object>();

            BybitParametersUtils.AddOptionalParameters(query,
                ("adjustId", adjustId),
                ("collateralCurrency", collateralCurrency),
                ("limit", limit),
                ("cursor", cursor)
            );

            var result = await this.SendSignedAsync<string>(GET_COLLATERAL_ADJUSTMENT_HISTORY, HttpMethod.Get, query: query);
            return result;
        }

        private const string GET_CRYPTO_LOAN_POSITION = "/v5/crypto-loan-common/position";

        /// <summary>
        /// Get Crypto Loan Position
        /// Spot trade permission required. Returns borrow, collateral, and supply positions.
        /// </summary>
        /// <returns></returns>
        public async Task<string?> GetCryptoLoanPosition()
        {
            var result = await this.SendSignedAsync<string>(GET_CRYPTO_LOAN_POSITION, HttpMethod.Get);
            return result;
        }

        private const string BORROW_FLEXIBLE_LOAN = "/v5/crypto-loan-flexible/borrow";

        /// <summary>
        /// Flexible Borrow
        /// Borrow with optional collateral list. Funds move to/from Funding wallet.
        /// </summary>
        /// <param name="loanCurrency">Loan coin</param>
        /// <param name="loanAmount">Amount to borrow</param>
        /// <param name="collateralList">
        /// Optional list of (collateralCurrency, collateralAmount). Up to 100 items.
        /// </param>
        /// <returns></returns>
        public async Task<string?> BorrowFlexibleLoan(
            string loanCurrency,
            string loanAmount,
            IEnumerable<(string collateralCurrency, string collateralAmount)>? collateralList = null)
        {
            var body = new Dictionary<string, object>
            {
                { "loanCurrency", loanCurrency },
                { "loanAmount", loanAmount }
            };

            if (collateralList != null)
            {
                body["collateralList"] = collateralList
                    .Select(c => new Dictionary<string, object>
                    {
                { "collateralCurrency", c.collateralCurrency },
                { "collateralAmount", c.collateralAmount }
                    })
                    .ToList();
            }

            var result = await this.SendSignedAsync<string>(BORROW_FLEXIBLE_LOAN, HttpMethod.Post, query: body);
            return result;
        }

        private const string REPAY_FLEXIBLE_LOAN = "/v5/crypto-loan-flexible/repay";

        /// <summary>
        /// Flexible Repay
        /// Fully or partially repay a flexible loan. Funds are deducted from Funding wallet.
        /// </summary>
        /// <param name="loanCurrency">Loan currency</param>
        /// <param name="amount">Repay amount</param>
        /// <returns></returns>
        public async Task<string?> RepayFlexibleLoan(string loanCurrency, string amount)
        {
            var body = new Dictionary<string, object>
            {
                { "loanCurrency", loanCurrency },
                { "amount", amount }
            };

            var result = await this.SendSignedAsync<string>(REPAY_FLEXIBLE_LOAN, HttpMethod.Post, query: body);
            return result;
        }

        private const string REPAY_COLLATERAL_FLEXIBLE = "/v5/crypto-loan-flexible/repay-collateral";

        /// <summary>
        /// Flexible Collateral Repayment
        /// Pay interest first, then principal. Spot trade permission required.
        /// </summary>
        /// <param name="loanCurrency">Loan currency</param>
        /// <param name="collateralCoin">Collateral currencies, comma-separated for multiple</param>
        /// <param name="amount">Repay amount</param>
        /// <returns></returns>
        public async Task<string?> RepayCollateralFlexible(string loanCurrency, string collateralCoin, string amount)
        {
            var body = new Dictionary<string, object>
            {
                { "loanCurrency", loanCurrency },
                { "collateralCoin", collateralCoin },
                { "amount", amount }
            };

            var result = await this.SendSignedAsync<string>(REPAY_COLLATERAL_FLEXIBLE, HttpMethod.Post, query: body);
            return result;
        }

        private const string GET_FLEXIBLE_LOANS = "/v5/crypto-loan-flexible/ongoing-coin";

        /// <summary>
        /// Flexible: Get Flexible loans
        /// Query ongoing flexible loans.
        /// </summary>
        /// <param name="loanCurrency">Optional loan coin</param>
        /// <returns></returns>
        public async Task<string?> GetFlexibleLoans(string? loanCurrency = null)
        {
            var query = new Dictionary<string, object>();
            BybitParametersUtils.AddOptionalParameters(query, ("loanCurrency", loanCurrency));

            var result = await this.SendSignedAsync<string>(GET_FLEXIBLE_LOANS, HttpMethod.Get, query: query);
            return result;
        }

        private const string GET_FLEXIBLE_BORROW_ORDERS_HISTORY = "/v5/crypto-loan-flexible/borrow-history";

        /// <summary>
        /// Flexible: Get Borrow Orders History
        /// </summary>
        /// <param name="orderId">Loan order ID</param>
        /// <param name="loanCurrency">Loan coin</param>
        /// <param name="limit">[1,100], default 10</param>
        /// <param name="cursor">pagination cursor</param>
        /// <returns></returns>
        public async Task<string?> GetFlexibleBorrowOrdersHistory(
            string? orderId = null,
            string? loanCurrency = null,
            string? limit = null,
            string? cursor = null)
        {
            var query = new Dictionary<string, object>();

            BybitParametersUtils.AddOptionalParameters(query,
                ("orderId", orderId),
                ("loanCurrency", loanCurrency),
                ("limit", limit),
                ("cursor", cursor)
            );

            var result = await this.SendSignedAsync<string>(GET_FLEXIBLE_BORROW_ORDERS_HISTORY, HttpMethod.Get, query: query);
            return result;
        }

        private const string GET_FLEXIBLE_REPAYMENT_ORDERS_HISTORY = "/v5/crypto-loan-flexible/repayment-history";

        /// <summary>
        /// Flexible: Get Repayment Orders History
        /// </summary>
        /// <param name="repayId">Repayment transaction ID</param>
        /// <param name="loanCurrency">Loan coin</param>
        /// <param name="limit">[1,100], default 10</param>
        /// <param name="cursor">pagination cursor</param>
        /// <returns></returns>
        public async Task<string?> GetFlexibleRepaymentOrdersHistory(
            string? repayId = null,
            string? loanCurrency = null,
            string? limit = null,
            string? cursor = null)
        {
            var query = new Dictionary<string, object>();

            BybitParametersUtils.AddOptionalParameters(query,
                ("repayId", repayId),
                ("loanCurrency", loanCurrency),
                ("limit", limit),
                ("cursor", cursor)
            );

            var result = await this.SendSignedAsync<string>(GET_FLEXIBLE_REPAYMENT_ORDERS_HISTORY, HttpMethod.Get, query: query);
            return result;
        }

        private const string GET_SUPPLYING_MARKET_FIXED = "/v5/crypto-loan-fixed/supply-order-quote";

        /// <summary>
        /// Fixed: Get Supplying Market
        /// Public. Check available counterparty borrow orders for supplying.
        /// </summary>
        /// <param name="orderCurrency">Coin name</param>
        /// <param name="orderBy">apy | term | quantity</param>
        /// <param name="term">7 | 14 | 30 | 90 | 180</param>
        /// <param name="sort">0 asc (default), 1 desc</param>
        /// <param name="limit">[1,100], default 10</param>
        /// <returns></returns>
        public async Task<string?> GetSupplyingMarketFixed(
            string orderCurrency,
            string orderBy,
            int? term = null,
            int? sort = null,
            int? limit = null)
        {
            var query = new Dictionary<string, object>
            {
                { "orderCurrency", orderCurrency },
                { "orderBy", orderBy }
            };

            BybitParametersUtils.AddOptionalParameters(query,
                ("term", term),
                ("sort", sort),
                ("limit", limit)
            );

            var result = await this.SendPublicAsync<string>(GET_SUPPLYING_MARKET_FIXED, HttpMethod.Get, query: query);
            return result;
        }

        private const string GET_BORROWING_MARKET_FIXED = "/v5/crypto-loan-fixed/borrow-order-quote";

        /// <summary>
        /// Fixed: Get Borrowing Market
        /// Public. Check available counterparty supply orders for borrowing.
        /// </summary>
        /// <param name="orderCurrency">Coin name</param>
        /// <param name="orderBy">apy | term | quantity</param>
        /// <param name="term">7 | 14 | 30 | 90 | 180</param>
        /// <param name="sort">0 asc (default), 1 desc</param>
        /// <param name="limit">[1,100], default 10</param>
        /// <returns></returns>
        public async Task<string?> GetBorrowingMarketFixed(
            string orderCurrency,
            string orderBy,
            int? term = null,
            int? sort = null,
            int? limit = null)
        {
            var query = new Dictionary<string, object>
            {
                { "orderCurrency", orderCurrency },
                { "orderBy", orderBy }
            };

            BybitParametersUtils.AddOptionalParameters(query,
                ("term", term),
                ("sort", sort),
                ("limit", limit)
            );

            var result = await this.SendPublicAsync<string>(GET_BORROWING_MARKET_FIXED, HttpMethod.Get, query: query);
            return result;
        }

        private const string CREATE_BORROW_ORDER_FIXED = "/v5/crypto-loan-fixed/borrow";

        /// <summary>
        /// Fixed: Create Borrow Order
        /// Create a fixed-term borrow order. Funds move to/from Funding wallet.
        /// </summary>
        /// <param name="orderCurrency">Currency to borrow</param>
        /// <param name="orderAmount">Amount to borrow</param>
        /// <param name="annualRate">Annual interest rate, e.g., "0.02"</param>
        /// <param name="term">7 | 14 | 30 | 90 | 180 (days)</param>
        /// <param name="autoRepay">"true" to enable, "false" to disable</param>
        /// <param name="collateralList">Optional list of (currency, amount), up to 100</param>
        /// <returns></returns>
        public async Task<string?> CreateBorrowOrderFixed(
            string orderCurrency,
            string orderAmount,
            string annualRate,
            string term,
            string? autoRepay = null,
            IEnumerable<(string currency, string amount)>? collateralList = null)
        {
            var body = new Dictionary<string, object>
            {
                { "orderCurrency", orderCurrency },
                { "orderAmount", orderAmount },
                { "annualRate", annualRate },
                { "term", term }
            };

            BybitParametersUtils.AddOptionalParameters(body, ("autoRepay", autoRepay));

            if (collateralList != null)
            {
                body["collateralList"] = collateralList
                    .Select(x => new Dictionary<string, object>
                    {
                { "currency", x.currency },
                { "amount", x.amount }
                    }).ToList();
            }

            var result = await this.SendSignedAsync<string>(CREATE_BORROW_ORDER_FIXED, HttpMethod.Post, query: body);
            return result;
        }

        private const string CREATE_SUPPLY_ORDER_FIXED = "/v5/crypto-loan-fixed/supply";

        /// <summary>
        /// Fixed: Create Supply Order
        /// Create a fixed-term supply order.
        /// </summary>
        /// <param name="orderCurrency">Currency to supply</param>
        /// <param name="orderAmount">Amount to supply</param>
        /// <param name="annualRate">Annual interest rate, e.g., "0.02"</param>
        /// <param name="term">7 | 14 | 30 | 90 | 180 (days)</param>
        /// <returns></returns>
        public async Task<string?> CreateSupplyOrderFixed(
            string orderCurrency,
            string orderAmount,
            string annualRate,
            string term)
        {
            var body = new Dictionary<string, object>
            {
                { "orderCurrency", orderCurrency },
                { "orderAmount", orderAmount },
                { "annualRate", annualRate },
                { "term", term }
            };

            var result = await this.SendSignedAsync<string>(CREATE_SUPPLY_ORDER_FIXED, HttpMethod.Post, query: body);
            return result;
        }

        private const string CANCEL_BORROW_ORDER_FIXED = "/v5/crypto-loan-fixed/borrow-order-cancel";

        /// <summary>
        /// Fixed: Cancel Borrow Order
        /// Cancel a fixed borrow order.
        /// </summary>
        /// <param name="orderId">Fixed borrow order ID</param>
        /// <returns></returns>
        public async Task<string?> CancelBorrowOrderFixed(string orderId)
        {
            var body = new Dictionary<string, object>
            {
                { "orderId", orderId }
            };

            var result = await this.SendSignedAsync<string>(CANCEL_BORROW_ORDER_FIXED, HttpMethod.Post, query: body);
            return result;
        }

        private const string CANCEL_SUPPLY_ORDER_FIXED = "/v5/crypto-loan-fixed/supply-order-cancel";

        /// <summary>
        /// Fixed: Cancel Supply Order
        /// Cancel a fixed supply order.
        /// </summary>
        /// <param name="orderId">Fixed supply order ID</param>
        /// <returns></returns>
        public async Task<string?> CancelSupplyOrderFixed(string orderId)
        {
            var body = new Dictionary<string, object>
            {
                { "orderId", orderId }
            };

            var result = await this.SendSignedAsync<string>(CANCEL_SUPPLY_ORDER_FIXED, HttpMethod.Post, query: body);
            return result;
        }

        private const string GET_BORROW_CONTRACT_INFO_FIXED = "/v5/crypto-loan-fixed/borrow-contract-info";

        /// <summary>
        /// Fixed: Get Borrow Contract Info
        /// Spot trade permission required. Returns fixed-term borrow contracts.
        /// </summary>
        /// <param name="orderId">Loan order ID</param>
        /// <param name="loanId">Loan ID</param>
        /// <param name="orderCurrency">Loan coin</param>
        /// <param name="term">7 | 14 | 30 | 90 | 180</param>
        /// <param name="limit">[1,100], default 10</param>
        /// <param name="cursor">pagination cursor</param>
        /// <returns></returns>
        public async Task<string?> GetBorrowContractInfoFixed(
            string? orderId = null,
            string? loanId = null,
            string? orderCurrency = null,
            string? term = null,
            string? limit = null,
            string? cursor = null)
        {
            var query = new Dictionary<string, object>();

            BybitParametersUtils.AddOptionalParameters(query,
                ("orderId", orderId),
                ("loanId", loanId),
                ("orderCurrency", orderCurrency),
                ("term", term),
                ("limit", limit),
                ("cursor", cursor)
            );

            var result = await this.SendSignedAsync<string>(GET_BORROW_CONTRACT_INFO_FIXED, HttpMethod.Get, query: query);
            return result;
        }

        private const string GET_SUPPLY_CONTRACT_INFO_FIXED = "/v5/crypto-loan-fixed/supply-contract-info";

        /// <summary>
        /// Fixed: Get Supply Contract Info
        /// Spot trade permission required. Returns fixed-term supply contracts.
        /// </summary>
        /// <param name="orderId">Supply order ID</param>
        /// <param name="supplyId">Supply contract ID</param>
        /// <param name="supplyCurrency">Supply coin</param>
        /// <param name="term">7 | 14 | 30 | 90 | 180</param>
        /// <param name="limit">[1,100], default 10</param>
        /// <param name="cursor">pagination cursor</param>
        /// <returns></returns>
        public async Task<string?> GetSupplyContractInfoFixed(
            string? orderId = null,
            string? supplyId = null,
            string? supplyCurrency = null,
            string? term = null,
            string? limit = null,
            string? cursor = null)
        {
            var query = new Dictionary<string, object>();

            BybitParametersUtils.AddOptionalParameters(query,
                ("orderId", orderId),
                ("supplyId", supplyId),
                ("supplyCurrency", supplyCurrency),
                ("term", term),
                ("limit", limit),
                ("cursor", cursor)
            );

            var result = await this.SendSignedAsync<string>(GET_SUPPLY_CONTRACT_INFO_FIXED, HttpMethod.Get, query: query);
            return result;
        }

        private const string GET_BORROW_ORDER_INFO_FIXED = "/v5/crypto-loan-fixed/borrow-order-info";

        /// <summary>
        /// Fixed: Get Borrow Order Info
        /// Spot trade permission required. Query fixed borrow orders.
        /// </summary>
        /// <param name="orderId">Loan order ID</param>
        /// <param name="orderCurrency">Loan coin</param>
        /// <param name="state">1 matching; 2 partially filled and cancelled; 3 fully filled; 4 cancelled</param>
        /// <param name="term">7 | 14 | 30 | 90 | 180</param>
        /// <param name="limit">[1,100], default 10</param>
        /// <param name="cursor">pagination cursor</param>
        /// <returns></returns>
        public async Task<string?> GetBorrowOrderInfoFixed(
            string? orderId = null,
            string? orderCurrency = null,
            string? state = null,
            string? term = null,
            string? limit = null,
            string? cursor = null)
        {
            var query = new Dictionary<string, object>();

            BybitParametersUtils.AddOptionalParameters(query,
                ("orderId", orderId),
                ("orderCurrency", orderCurrency),
                ("state", state),
                ("term", term),
                ("limit", limit),
                ("cursor", cursor)
            );

            var result = await this.SendSignedAsync<string>(GET_BORROW_ORDER_INFO_FIXED, HttpMethod.Get, query: query);
            return result;
        }

        private const string GET_SUPPLY_ORDER_INFO_FIXED = "/v5/crypto-loan-fixed/supply-order-info";

        /// <summary>
        /// Fixed: Get Supply Order Info
        /// Spot trade permission required. Query fixed supply orders.
        /// </summary>
        /// <param name="orderId">Supply order ID</param>
        /// <param name="orderCurrency">Supply coin</param>
        /// <param name="state">1 matching; 2 partially filled and cancelled; 3 fully filled; 4 cancelled</param>
        /// <param name="term">7 | 14 | 30 | 90 | 180</param>
        /// <param name="limit">[1,100], default 10</param>
        /// <param name="cursor">pagination cursor</param>
        /// <returns></returns>
        public async Task<string?> GetSupplyOrderInfoFixed(
            string? orderId = null,
            string? orderCurrency = null,
            string? state = null,
            string? term = null,
            string? limit = null,
            string? cursor = null)
        {
            var query = new Dictionary<string, object>();

            BybitParametersUtils.AddOptionalParameters(query,
                ("orderId", orderId),
                ("orderCurrency", orderCurrency),
                ("state", state),
                ("term", term),
                ("limit", limit),
                ("cursor", cursor)
            );

            var result = await this.SendSignedAsync<string>(GET_SUPPLY_ORDER_INFO_FIXED, HttpMethod.Get, query: query);
            return result;
        }

        private const string REPAY_FIXED_LOAN = "/v5/crypto-loan-fixed/fully-repay";

        /// <summary>
        /// Fixed: Repay
        /// Fully repay a fixed loan. Pass either loanId or loanCurrency.
        /// </summary>
        /// <param name="loanId">Loan contract ID</param>
        /// <param name="loanCurrency">Loan coin</param>
        /// <returns></returns>
        public async Task<string?> RepayFixedLoan(string? loanId = null, string? loanCurrency = null)
        {
            var body = new Dictionary<string, object>();
            BybitParametersUtils.AddOptionalParameters(body,
                ("loanId", loanId),
                ("loanCurrency", loanCurrency)
            );

            var result = await this.SendSignedAsync<string>(REPAY_FIXED_LOAN, HttpMethod.Post, query: body);
            return result;
        }

        private const string REPAY_COLLATERAL_FIXED = "/v5/crypto-loan-fixed/repay-collateral";

        /// <summary>
        /// Fixed: Collateral Repayment
        /// Pays interest first, then principal. If <paramref name="loanId"/> is null, fixed-currency offset logic applies.
        /// </summary>
        /// <param name="loanCurrency">Loan currency</param>
        /// <param name="collateralCoin">Collateral currencies, comma-separated</param>
        /// <param name="amount">Repay amount</param>
        /// <param name="loanId">Loan contract ID (optional)</param>
        /// <returns></returns>
        public async Task<string?> RepayCollateralFixed(string loanCurrency, string collateralCoin, string amount, string? loanId = null)
        {
            var body = new Dictionary<string, object>
            {
                { "loanCurrency", loanCurrency },
                { "collateralCoin", collateralCoin },
                { "amount", amount }
            };
            BybitParametersUtils.AddOptionalParameters(body, ("loanId", loanId));

            var result = await this.SendSignedAsync<string>(REPAY_COLLATERAL_FIXED, HttpMethod.Post, query: body);
            return result;
        }

        private const string GET_REPAYMENT_HISTORY_FIXED = "/v5/crypto-loan-fixed/repayment-history";

        /// <summary>
        /// Fixed: Get Repayment History
        /// Spot trade permission required. Paginated.
        /// </summary>
        /// <param name="repayId">Repayment order ID</param>
        /// <param name="loanCurrency">Loan coin name</param>
        /// <param name="limit">[1,100], default 10</param>
        /// <param name="cursor">pagination cursor</param>
        /// <returns></returns>
        public async Task<string?> GetRepaymentHistoryFixed(
            string? repayId = null,
            string? loanCurrency = null,
            string? limit = null,
            string? cursor = null)
        {
            var query = new Dictionary<string, object>();

            BybitParametersUtils.AddOptionalParameters(query,
                ("repayId", repayId),
                ("loanCurrency", loanCurrency),
                ("limit", limit),
                ("cursor", cursor)
            );

            var result = await this.SendSignedAsync<string>(GET_REPAYMENT_HISTORY_FIXED, HttpMethod.Get, query: query);
            return result;
        }
    }
}
