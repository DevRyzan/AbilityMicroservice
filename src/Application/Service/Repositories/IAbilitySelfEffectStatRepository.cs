using Core.Persistence.Repositories.ReadRepositories;
using Core.Persistence.Repositories.WriteRepositories;
using Domain.Abilities;

namespace Application.Service.Repositories;

public interface IAbilitySelfEffectStatRepository : IReadRepository<AbilitySelfEffectStat, string>, IWriteRepository<AbilitySelfEffectStat, string>
{
}
