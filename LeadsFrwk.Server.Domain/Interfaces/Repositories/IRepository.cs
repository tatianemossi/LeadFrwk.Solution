using System.Linq.Expressions;

namespace LeadsFrwk.Server.Domain.Interfaces.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<T> AddAsync(T entity, CancellationToken cancellationToken);
        Task UpdateAsync(T entity, CancellationToken cancellationToken);
        Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken);
        Task<T?> GetByIdAsync(int id, CancellationToken cancellationToken);
        Task<IEnumerable<T>> GetManyAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken);
        Task RemoveAsync(T entity, CancellationToken cancellationToken);
    }
}
