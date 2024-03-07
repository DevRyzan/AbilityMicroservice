using Application.Service.Repositories;
using Core.Persistence.Repositories;
using Core.Persistence.Repositories.Settings;
using Domain.Abilities;
using Microsoft.Extensions.Options;


namespace Persistence.Repositories.AbilityRepositories;

public class AbilityAllyEffectStatRepository : MongoDbRepositoryBase<AbilityAllyEffectStat, string>, IAbilityAllyEffectStatRepository
{
    public AbilityAllyEffectStatRepository(IOptions<MongoDbSettings> options) : base(options)
    {
    }
}
