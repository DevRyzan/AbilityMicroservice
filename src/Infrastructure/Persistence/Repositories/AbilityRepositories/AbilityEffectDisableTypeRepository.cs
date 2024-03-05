using Application.Service.Repositories;
using Core.Persistence.Repositories;
using Core.Persistence.Repositories.Settings;
using Domain.Abilities;
using Microsoft.Extensions.Options;


namespace Persistence.Repositories.AbilityRepositories;

public class AbilityEffectDisableTypeRepository : MongoDbRepositoryBase<AbilityEffectDisableType, string>, IAbilityEffectDisableTypeRepository
{
    public AbilityEffectDisableTypeRepository(IOptions<MongoDbSettings> options) : base(options)
    {
    }
}
