using Core.Persistence.Repositories.ReadRepositories;
using Core.Persistence.Repositories.WriteRepositories;
using Domain.Abilities;

namespace Application.Service.Repositories;


public interface IAbilityEnemyEffectStatRepository : IReadRepository<AbilityEnemyEffectStat, string>, IWriteRepository<AbilityEnemyEffectStat, string>
{
}
