using System;
using System.Collections.Generic;
using TradePMR.DanielSerrano.Common;

namespace TradePMR.DanielSerrano.Data
{
    public static class Seeder
    {
        public static IEnumerable<Account> Accounts()
        {
            return new Account[]
            {
                new Account()
                {
                    Id = 1,
                    Name = "Steve",
                    DateCreated = DateTime.Parse("2019-04-19 00:00:00.000"),
                    DateUpdated = DateTime.Parse("2019-04-21 00:00:00.000"),
                },
                new Account()
                {
                    Id = 2,
                    Name = "George",
                    DateCreated = DateTime.Parse("2019-04-21 00:00:00.000"),
                    DateUpdated = DateTime.Parse("2019-04-21 12:00:00.000"),
                }
            };
        }

        public static IEnumerable<Trade> Trades()
        {
            return new Trade[]
            {
                new Trade()
                {
                    Id = 1,
                    AccountId = 1,
                    Symbol = "GE",
                    Quantity = 10,
                    Action = TradeActions.Buy,
                    DateCreated = DateTime.Parse("2019-05-20 00:00:00.000"),
                    DateUpdated = DateTime.Parse("2019-05-21 00:00:00.000")
                },
                new Trade()
                {
                    Id = 2,
                    AccountId = 2,
                    Symbol = "GE",
                    Quantity = 10,
                    Action = TradeActions.Sell,
                    DateCreated = DateTime.Parse("2019-05-20 00:00:00.000"),
                    DateUpdated = DateTime.Parse("2019-05-21 00:00:00.000")
                },
                new Trade()
                {
                    Id = 3,
                    AccountId = 1,
                    Symbol = "AAPL",
                    Quantity = 10,
                    Action = TradeActions.Buy,
                    DateCreated = DateTime.Parse("2019-05-20 00:00:00.000"),
                    DateUpdated = DateTime.Parse("2019-05-21 00:00:00.000")
                }
            };
        }

    }
}
