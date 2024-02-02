using Core.Persistence.Repositories.ReadRepositories;
using Core.Persistence.Repositories.WriteRepositories;
using Domain.Abilities;

namespace Application.Service.Repositories;

public interface IAbilityTargetTypeRepository : IReadRepository<AbilityTargetType, Guid>, IWriteRepository<AbilityTargetType, Guid>
{
}
