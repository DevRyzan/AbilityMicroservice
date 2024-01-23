using System.Linq.Expressions;

namespace Core.Persistence.Repositories.WriteRepositories;

public interface IWriteRepository<T, TIdType> : IQuery<T> where T : Entity<TIdType>
{
    Task<T> AddAsync(T entity);
    Task<bool> AddRangeAsync(IEnumerable<T> entities);
    Task<T> UpdateAsync(TIdType id, T entity);
    Task<T> UpdateAsync(T entity, Expression<Func<T, bool>> predicate);
    Task<T> DeleteAsync(T entity);
    Task<T> DeleteAsync(TIdType id);
    Task<T> DeleteAsync(Expression<Func<T, bool>> predicate);
}
