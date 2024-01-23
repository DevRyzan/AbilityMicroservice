using Core.Persistence.Paging;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace Core.Persistence.Repositories.ReadRepositories;

public interface IReadRepository<T, TIdType> : IQuery<T> where T : Entity<TIdType>
{
    IQueryable<T> GetList(Expression<Func<T, bool>> predicate = null);
    Task<T> GetAsync(Expression<Func<T, bool>> predicate);
    Task<T> GetByIdAsync(TIdType id);
}

