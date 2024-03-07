using Application.Service.Repositories;
using Core.Persistence.Repositories;
using Core.Persistence.Repositories.Settings;
using Domain.Abilities;
using Microsoft.Extensions.Options;

namespace Persistence.Repositories.AbilityRepositories;

public class AbilityEnemyEffectStatRepository : MongoDbRepositoryBase<AbilityEnemyEffectStat, string>, IAbilityEnemyEffectStatRepository
{
    public AbilityEnemyEffectStatRepository(IOptions<MongoDbSettings> options) : base(options)
    {
    }
}
