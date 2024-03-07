using Application.Service.Repositories;
using Core.Persistence.Repositories;
using Core.Persistence.Repositories.Settings;
using Domain.Abilities;
using Microsoft.Extensions.Options;

namespace Persistence.Repositories.AbilityRepositories;

public class AbilityAttackStatRepository : MongoDbRepositoryBase<AbilityAttackStat, string>, IAbilityAttackStatRepository
{
    public AbilityAttackStatRepository(IOptions<MongoDbSettings> options) : base(options)
    {
    }
}
