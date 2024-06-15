using Leads.Domain.Aggregates;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leads.Data.Contexts
{
    public class LeadsDbContext : DbContext
    {
        internal string _connectionString;

        public DbSet<Lead> Leads { get; set; }  

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connectionString, op => op.MigrationsHistoryTable("__EFMigrationsHistory"));
            }

            optionsBuilder.EnableSensitiveDataLogging();

            base.OnConfiguring(optionsBuilder);
        }

        public void SetConnection(string connectionString)
        {
            _connectionString = connectionString;

            Database.GetDbConnection().ConnectionString = _connectionString;
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellation = default)
        {
            var insertedEntries = ChangeTracker
                .Entries()
                .Where(en => en.State == EntityState.Added)
                .Select(en => en.Entity);


            var modifiedEntries = ChangeTracker
                .Entries()
                .Where(en => en.State == EntityState.Modified)
                .Select(en => en.Entity);

            //TO-DO MODIFIEDDATE AND ENTRYDATE

            return base.SaveChangesAsync(cancellation);
        }


    }
}
