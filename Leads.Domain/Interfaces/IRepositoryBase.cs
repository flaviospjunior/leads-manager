namespace Leads.Domain.Interfaces
{
    public interface IRepositoryBase<T> where T : class, IAggregateRoot
    {
        Task<T> CreateAsync(T entity);  
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<T> GetByIdAsync(Guid id);
        Task<ICollection<T>> GetAllAsync();
        Task<ICollection<T>> CreateAsync(ICollection<T> entities);
        Task UpdateAsync(ICollection<T> entities);
        Task DeleteAsync(ICollection<T> entities);
        void Dispose();
    }
}
