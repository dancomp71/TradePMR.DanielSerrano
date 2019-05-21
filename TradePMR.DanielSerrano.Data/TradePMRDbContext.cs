using Microsoft.EntityFrameworkCore;
using TradePMR.DanielSerrano.Common;

namespace TradePMR.DanielSerrano.Data
{
    public class TradePMRDbContext : DbContext
    {
        public TradePMRDbContext(DbContextOptions<TradePMRDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Seed();
        }

        public DbSet<Account> Accounts { get; set; }

        public DbSet<Trade> Trades { get; set; }

    }
}
