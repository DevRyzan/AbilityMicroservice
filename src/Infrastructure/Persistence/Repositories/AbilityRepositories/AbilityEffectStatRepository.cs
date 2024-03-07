using Application.Service.Repositories;
using Core.Persistence.Repositories;
using Core.Persistence.Repositories.Settings;
using Domain.Abilities;
using Microsoft.Extensions.Options;

namespace Persistence.Repositories.AbilityRepositories;

public class AbilityEffectStatRepository : MongoDbRepositoryBase<AbilityEffectStat, string>, IAbilityEffectStatRepository
{
    public AbilityEffectStatRepository(IOptions<MongoDbSettings> options) : base(options)
    {
    }
}