# TradePMR.DanielSerrano

my test project for tradepmr

This high-level goal of this exercise is for you to create an API for interacting with accounts and trades. We ask that you please use EntityFramework and WebAPI, while other technology choices, such as taking code-first or database-first approach, are up to your discretion.

Create an Account table with the columns, Id, Name, DateCreated, and DateUpdated, as in the following example:

Account
Id	Name	DateCreated	DateUpdated
1	Steve	2019-04-19 00:00:00.000	2019-04-21 00:00:00.000
2	George	2019-04-21 00:00:00.000	2019-04-21 12:00:00.000

Create a Trade table with the columns, Id, AccountId, Symbol, Quantity, Action, DateCreated, and DateUpdated, as in the following example:

Trade
Id	AccountId	Symbol	Quantity	Action	DateCreated	DateUpdated
1	1	GE	10	Buy	2019-05-20 00:00:00.000	2019-05-21 00:00:00.000
2	2	GE	10	Sell	2019-05-20 00:00:00.000	2019-05-21 00:00:00.000
3	1	AAPL	10	Buy	2019-05-20 00:00:00.000	2019-05-21 00:00:00.000

Note that AccountId should map to a record in the Account table.

Next, create a set of API calls to service each of these tables.

For the accounts, include a POST endpoint for creating an account, as well as GET, PUT, and DELETE by id endpoints for interacting with an existing record by id. Also, include a paginated endpoint that allows accounts to be queried by Name.

For the trades, include a POST endpoint for creating a trade, as well as GET, PUT, and DELETE by id endpoints for interacting with an existing record by id. Also, include a paginated endpoint that allows trades to be queried by DateCreated, Symbol, Action, and AccountId.

For the trade PUT call, a trade should not be able to have its AccountId changed or deleted. Incoming payloads for all API endpoints should be validated.

Bonus: Include unit tests. Include a way to “soft delete” entities without actually removing records.
