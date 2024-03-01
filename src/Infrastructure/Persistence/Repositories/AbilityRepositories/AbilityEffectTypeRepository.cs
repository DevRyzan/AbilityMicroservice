using Application.Service.Repositories;
using Core.Persistence.Repositories;
using Core.Persistence.Repositories.Settings;
using Domain.Abilities;
using Microsoft.Extensions.Options;


namespace Persistence.Repositories.AbilityRepositories;

public class AbilityEffectTypeRepository : MongoDbRepositoryBase<AbilityEffectType, string>, IAbilityEffectTypeRepository
{
    public AbilityEffectTypeRepository(IOptions<MongoDbSettings> options) : base(options)
    {
    }
}
