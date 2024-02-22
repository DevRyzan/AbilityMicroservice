using Application.Service.Repositories;
using Core.Persistence.Repositories;
using Core.Persistence.Repositories.Settings;
using Domain.Abilities;
using Microsoft.Extensions.Options;

namespace Persistence.Repositories.AbilityRepositories;

public class ResourceCostTypeRepository : MongoDbRepositoryBase<ResourceCostType, string>, IResourceCostTypeRepository
{
    public ResourceCostTypeRepository(IOptions<MongoDbSettings> options) : base(options)
    {
    }
}
