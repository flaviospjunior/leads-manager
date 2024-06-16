using Leads.Domain.Aggregates.Lead;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace Leads.Data.Contexts
{
    public class LeadsDbContext : DbContext
    {
        public DbSet<Lead> Leads { get; set; }


        public LeadsDbContext(DbContextOptions<LeadsDbContext> options) : base(options)
        {
            
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
