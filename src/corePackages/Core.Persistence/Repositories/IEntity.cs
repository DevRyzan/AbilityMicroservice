namespace Core.Persistence.Repositories;

public interface IEntity
{
}

public interface IEntity<TEntity> where TEntity : Entity<int>
{
    public string? Code { get; set; }
}

