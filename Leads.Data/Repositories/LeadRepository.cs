using Leads.Data.Contexts;
using Leads.Domain.Aggregates.Lead;
using Leads.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Leads.Data.Repositories
{
    public class LeadRepository : RepositoryBase<Lead>, ILeadRepository
    {
        private LeadsDbContext _context;

        public LeadRepository(LeadsDbContext context) : base(context)
        {
            _context = context;

        }

        public async Task<Lead> GetByIdWithSuburbAndContact(Guid id)
        {
            return await _context.Leads
                .Include(ld => ld.Suburb)
                .Include(ld => ld.Contact)
                .FirstOrDefaultAsync(ld => ld.Id.Equals(id));
        }

        public async Task<List<Lead>> GetAllWithContactAndSuburb()
        {
            return await _context.Leads.AsNoTracking()
                .Include(ld => ld.Suburb)
                .Include(ld => ld.Contact)
                .ToListAsync();
        }

    }
}
