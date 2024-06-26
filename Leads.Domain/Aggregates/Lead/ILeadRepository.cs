﻿using Leads.Domain.Interfaces;

namespace Leads.Domain.Aggregates.Lead
{
    public interface ILeadRepository : IRepositoryBase<Lead>
    {
        Task<Lead> GetByIdCompleteAsync(Guid Id);
        Task<List<Lead>> GetAllCompleteAsync();
    }
}
