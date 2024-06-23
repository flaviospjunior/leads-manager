using Leads.Data.Contexts;
using Leads.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Leads.Data.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class, IAggregateRoot
    {
        protected readonly LeadsDbContext _context;
        //TODO - IMPLEMENT AUDITABLE ENTITY

        public RepositoryBase(LeadsDbContext context)
        {
            _context = context; 
        }

        public async Task<T> CreateAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return await Task.FromResult(entity);
        }

        public async Task<ICollection<T>> CreateAsync(ICollection<T> entities)
        {
            await _context.Set<T>().AddRangeAsync(entities);
            await _context.SaveChangesAsync();
            return await Task.FromResult(entities);
        }

        public async Task DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(ICollection<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
            await _context.SaveChangesAsync();
        }

        public async void Dispose()
        {
            await _context.DisposeAsync();
        }

        public async Task<ICollection<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            var entity = await _context.Set<T>().FindAsync(id);

            if (entity != null)
                _context.Entry(entity).State = EntityState.Detached;

            return entity;
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ICollection<T> entities)
        {
            _context.Entry(entities).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
