using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseMgmtDB
{
    public static class TemporalTablesExtensions
    {
        public static IQueryable<T> GetHistoryAtTime<T>(this DbSet<T> dbSet, string tableName, int id, DateTime time) where T : class
        {
            return dbSet.FromSqlRaw<T>($"SELECT * FROM dbo.[{tableName}] FOR SYSTEM_TIME AS OF {{0}} WHERE Id = {{1}} ORDER BY ValidFromUTC", time.ToUniversalTime(), id).AsNoTracking().AsQueryable();
        }
        public static IQueryable<T> GetHistoryAll<T>(this DbSet<T> dbSet, string tableName, int id) where T : class
        {
            return dbSet.FromSqlRaw<T>($"SELECT * FROM dbo.[{tableName}] FOR SYSTEM_TIME ALL WHERE Id = {{0}}  ORDER BY ValidFromUTC", id).AsNoTracking().AsQueryable();
        }

        public static string GetEnableTemporalTableSql(string tableName) =>
            $@"ALTER TABLE [dbo].[{tableName}] ADD PERIOD FOR SYSTEM_TIME (ValidFromUTC, ValidToUTC)
               GO
               ALTER TABLE [dbo].[{tableName}] SET (SYSTEM_VERSIONING = ON (HISTORY_TABLE =  [dbo].[{tableName}History], DATA_CONSISTENCY_CHECK = ON)) 
               GO";

    }
}
