using Core.Persistence.Repositories.ReadRepositories;
using Core.Persistence.Repositories.WriteRepositories;
using Domain.Abilities;

namespace Application.Service.Repositories;

public interface IAbilityRepository : IReadRepository<Ability, Guid>, IWriteRepository<Ability, Guid>
{
}
