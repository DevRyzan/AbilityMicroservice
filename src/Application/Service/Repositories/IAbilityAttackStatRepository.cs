using Core.Persistence.Repositories.ReadRepositories;
using Core.Persistence.Repositories.WriteRepositories;
using Domain.Abilities;

namespace Application.Service.Repositories;


public interface IAbilityAttackStatRepository : IReadRepository<AbilityAttackStat, string>, IWriteRepository<AbilityAttackStat, string>
{
}
