using Leads.Data.Contexts;
using Leads.Domain.Aggregates.Lead;

namespace Leads.Data.Repositories
{
    public class LeadRepository : RepositoryBase<Lead>, ILeadRepository
    {
        public LeadRepository(LeadsDbContext context) : base(context)
        {
        }
    }
}
