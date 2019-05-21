using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using TradePMR.DanielSerrano.Common;
using TradePMR.DanielSerrano.Data.Interfaces;
using TradePMR.DanielSerrano.Data.Models;

namespace TradePMR.DanielSerrano.Data.Repositories
{
    public class TradeRepository : ITradeRepository
    {
        private readonly TradePMRDbContext context;

        public TradeRepository(TradePMRDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<ValidationResult> Validate(Trade trade)
        {
            // TODO: add more validations
            return new ValidationResult[] { };
        }

        public Trade Add(Trade trade)
        {
            trade.DateCreated = trade.DateUpdated = DateTime.Now;
            context.Trades.Add(trade);
            context.SaveChanges();
            return trade;
        }

        public Trade Delete(int id)
        {
            var trade = context.Trades.FirstOrDefault(x => x.Id == id);
            if (trade == null)
                return null;
            context.Remove(trade);
            context.SaveChanges();
            return trade;
        }

        public IEnumerable<Trade> GetAll()
        {
            return context.Trades;
        }

        public Trade GetById(int id)
        {
            return context.Trades.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Trade> Query(TradeQueryParameter p)
        {
            var result = context.Trades.AsQueryable();

            if (p.DateCreated != null)
            {
                result = result.Where(x => x.DateCreated >= p.DateCreated.Value);
            }

            if (p.Symbol != null)
            {
                result = result.Where(x => x.Symbol == p.Symbol);
            }

            if (p.Action != null)
            {
                result = result.Where(x => x.Action == p.Action.Value);
            }

            if (p.AccountId != null)
            {
                result = result.Where(x => x.AccountId == p.AccountId.Value);
            }

            if (p.Skip != null)
                result = result.Skip(p.Skip.Value);

            if (p.Take != null)
                result = result.Take(p.Take.Value);

            return result.AsEnumerable();
        }

        public Trade Update(Trade trade)
        {
            var t = context.Trades.FirstOrDefault(x => x.Id == trade.Id);
            t.Id = trade.Id;
            t.Symbol = trade.Symbol;
            t.Quantity = trade.Quantity;
            t.Action = trade.Action;
            t.DateUpdated = DateTime.Now;
            context.Entry(t).State = EntityState.Modified;
            context.SaveChanges();
            return t;
        }
    }
}
