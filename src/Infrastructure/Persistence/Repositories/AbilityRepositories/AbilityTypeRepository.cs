using Application.Service.Repositories;
using Core.Persistence.Repositories;
using Core.Persistence.Repositories.Settings;
using Domain.Abilities;
using Microsoft.Extensions.Options;


namespace Persistence.Repositories.AbilityRepositories;

public class AbilityTypeRepository : MongoDbRepositoryBase<AbilityType, string>, IAbilityTypeRepository
{
    public AbilityTypeRepository(IOptions<MongoDbSettings> options) : base(options)
    {
    }
}
