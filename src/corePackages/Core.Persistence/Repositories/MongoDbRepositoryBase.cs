using Core.Persistence.Repositories.ReadRepositories;
using Core.Persistence.Repositories.Settings;
using Core.Persistence.Repositories.WriteRepositories;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace Core.Persistence.Repositories;

public abstract class MongoDbRepositoryBase<TEntity, TIdType> : IReadRepository<TEntity, TIdType>, IWriteRepository<TEntity, TIdType>
    where TEntity : Entity<TIdType>
{
    protected readonly IMongoCollection<TEntity> _collection;
    private readonly MongoDbSettings _settings;

    protected MongoDbRepositoryBase(IOptions<MongoDbSettings> options)
    {
        _settings = options.Value;
        var client = new MongoClient(_settings.ConnectionString);
        var database = client.GetDatabase(_settings.Database);
        _collection = database.GetCollection<TEntity>(typeof(TEntity).Name.ToLowerInvariant());
    }


    public virtual async Task<TEntity> AddAsync(TEntity entity)
    {
        var options = new InsertOneOptions { BypassDocumentValidation = false };
        await _collection.InsertOneAsync(entity, options);
        return entity;
    }

    public virtual async Task<bool> AddRangeAsync(IEnumerable<TEntity> entities)
    {
        var options = new BulkWriteOptions { IsOrdered = false, BypassDocumentValidation = false };
        return (await _collection.BulkWriteAsync((IEnumerable<WriteModel<TEntity>>)entities, options)).IsAcknowledged;
    }

    public virtual async Task<TEntity> UpdateAsync(TIdType id, TEntity entity)
    {
        return await _collection.FindOneAndReplaceAsync(x => x.Id.Equals(id), entity);
    }

    public virtual async Task<TEntity> UpdateAsync(TEntity entity, Expression<Func<TEntity, bool>> predicate)
    {
        return await _collection.FindOneAndReplaceAsync(predicate, entity);
    }

    public virtual async Task<TEntity> DeleteAsync(TEntity entity)
    {
        return await _collection.FindOneAndDeleteAsync(x => x.Id.Equals(entity.Id));
    }

    public virtual async Task<TEntity> DeleteAsync(TIdType id)
    {
        return await _collection.FindOneAndDeleteAsync(x => x.Id.Equals(id));
    }

    public virtual async Task<TEntity> DeleteAsync(Expression<Func<TEntity, bool>> filter)
    {
        return await _collection.FindOneAndDeleteAsync(filter);
    }

    public IQueryable<TEntity> Query()
    {
        throw new NotImplementedException();
    }

    public async Task<List<TEntity>> GetList(Expression<Func<TEntity, bool>> predicate = null, int index = 0, int size = 10)
    {
        var query = predicate == null ? _collection.Find(new BsonDocument()) : _collection.Find(predicate);
        var result = await query.Skip(index * size).Limit(size).ToListAsync();

        return result;
    }

    public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return await _collection.Find(predicate).FirstOrDefaultAsync();
    }

    public async Task<TEntity> GetByIdAsync(TIdType id)
    {
        return await _collection.Find(x => x.Id.Equals(id)).FirstOrDefaultAsync();
    }


}