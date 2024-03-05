using Application.Service.Repositories;
using Core.Persistence.Repositories;
using Core.Persistence.Repositories.Settings;
using Domain.Abilities;
using Microsoft.Extensions.Options;


namespace Persistence.Repositories.AbilityRepositories;

public class AbilityDamageTypeRepository : MongoDbRepositoryBase<AbilityDamageType, string>, IAbilityDamageTypeRepository
{
    public AbilityDamageTypeRepository(IOptions<MongoDbSettings> options) : base(options)
    {
    }
}
