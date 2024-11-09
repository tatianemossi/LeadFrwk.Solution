using LeadsFrwk.Server.Domain.Interfaces.Repositories;
using LeadsFrwk.Server.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace LeadsFrwk.Server.Infrastructure.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DatabaseContext _dbContext;

        public Repository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async virtual Task<T> AddAsync(T entity, CancellationToken cancellationToken)
        {
            _dbContext.Set<T>().Add(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return entity;
        }

        public async virtual Task UpdateAsync(T entity, CancellationToken cancellationToken)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async virtual Task<IEnumerable<T>> GetManyAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken)
        {
            return await Task.Run(() => _dbContext.Set<T>().Where(expression).AsEnumerable(), cancellationToken);
        }

        public async Task<T?> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async virtual Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await Task.Run(() => _dbContext.Set<T>().AsEnumerable(), cancellationToken);
        }

        public async Task RemoveAsync(T entity, CancellationToken cancellationToken)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
