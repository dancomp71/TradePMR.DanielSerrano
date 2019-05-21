using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using TradePMR.DanielSerrano.Common;

namespace TradePMR.DanielSerrano.Data
{
    public static class Extensions
    {
        /// <summary>
        /// seed builder with data
        /// </summary>
        public static void Seed(this ModelBuilder builder)
        {
            builder.Entity<Account>().HasData(Seeder.Accounts());
            builder.Entity<Trade>().HasData(Seeder.Trades());
        }

        /// <summary>
        /// see dbcontext with data
        /// </summary>
        public static TradePMRDbContext Seed(this TradePMRDbContext context)
        {
            if (!context.Accounts.Any())
            {
                context.AddRange(Seeder.Accounts());
                context.SaveChanges();
            }
            if (!context.Trades.Any())
            {
                context.AddRange(Seeder.Trades());
                context.SaveChanges();
            }
            return context;
        }

        /// <summary>
        /// seed appbuilder with data
        /// </summary>
        public static void Seed(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                serviceScope.ServiceProvider.GetRequiredService<TradePMRDbContext>();
                var context = serviceScope.ServiceProvider.GetRequiredService<TradePMRDbContext>();
                context.Database.Migrate();
                context.Database.EnsureCreated();
                //context.Seed();
            }
        }
    }
}
