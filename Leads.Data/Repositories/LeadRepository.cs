using Leads.Data.Contexts;
using Leads.Domain.Aggregates.Lead;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leads.Data.Repositories
{
    public class LeadRepository : RepositoryBase<Lead>, ILeadRepository
    {
        public LeadRepository(LeadsDbContext context) : base(context)
        {
        }
    }
}
