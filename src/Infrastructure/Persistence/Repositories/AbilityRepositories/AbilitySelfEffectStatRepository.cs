using Application.Service.Repositories;
using Core.Persistence.Repositories;
using Core.Persistence.Repositories.Settings;
using Domain.Abilities;
using Microsoft.Extensions.Options;

namespace Persistence.Repositories.AbilityRepositories;

public class AbilitySelfEffectStatRepository : MongoDbRepositoryBase<AbilitySelfEffectStat, string>, IAbilitySelfEffectStatRepository
{
    public AbilitySelfEffectStatRepository(IOptions<MongoDbSettings> options) : base(options)
    {
    }
}
