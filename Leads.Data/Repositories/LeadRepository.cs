using Leads.Data.Contexts;
using Leads.Domain.Aggregates.Lead;
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

        public async Task<Lead> GetByIdCompleteAsync(Guid id)
        {
            return await _context.Leads.AsNoTracking()
                .Include(ld => ld.Suburb)
                .Include(ld => ld.Contact)
                .Include(ld => ld.Category)
                .FirstOrDefaultAsync(ld => ld.Id.Equals(id));
        }

        public async Task<List<Lead>> GetAllCompleteAsync()
        {
            return await _context.Leads.AsNoTracking()
                .Include(ld => ld.Suburb)
                .Include(ld => ld.Contact)
                .Include(ld => ld.Category)
                .ToListAsync();
        }

    }
}
