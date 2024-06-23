using Leads.Domain.Aggregates.Lead;
using Leads.Tests.Data.Repositories;

namespace Leads.Tests.Fixture
{
    public class DbFixture : IDisposable
    {
        public ILeadRepository LeadRepository { get; private set; }

        public DbFixture()
        {
            LeadRepository = MockILeadRepository.GetMock().Object;
        }
        public void Dispose()
        {
            LeadRepository.Dispose();
        }
    }
}
