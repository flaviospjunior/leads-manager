using Leads.Domain.Interfaces;

namespace Leads.Domain.Aggregates.Lead
{
    public interface ILeadRepository : IRepositoryBase<Lead>
    {
        Task<Lead> GetByIdComplete(Guid Id);
        Task<List<Lead>> GetAllComplete();
    }
}
