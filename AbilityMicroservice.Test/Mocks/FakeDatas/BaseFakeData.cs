using Core.Persistence.Repositories;


namespace AbilityMicroservice.Test.Mocks.FakeDatas;

public abstract class BaseFakeData<TEntity, TEntityId>
    where TEntity : Entity<TEntityId>, new()
{
    public List<TEntity> Data => CreateFakeData();
    public abstract List<TEntity> CreateFakeData();
}
