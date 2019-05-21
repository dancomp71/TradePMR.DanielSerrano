using Microsoft.EntityFrameworkCore;
using System;

namespace TradePMR.DanielSerrano.Data
{
    public class IdentityInsert : IDisposable
    {
        private readonly DbContext context;
        private readonly string tableName;

        public IdentityInsert(DbContext context, string tableName)
        {
            this.context = context;
            this.tableName = tableName;
            Begin();
        }

        private void Begin()
        {
            context.Database.ExecuteSqlCommand(
                string.Format("SET IDENTITY_INSERT {0} ON", tableName)
            );
        }

        private void End()
        {
            context.Database.ExecuteSqlCommand(
                string.Format("SET IDENTITY_INSERT {0} OFF", tableName)
            );
        }

        public void Dispose()
        {
            End();
        }
    }
}
