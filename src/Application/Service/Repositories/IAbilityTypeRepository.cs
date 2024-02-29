using Core.Persistence.Repositories.ReadRepositories;
using Core.Persistence.Repositories.WriteRepositories;
using Domain.Abilities;

namespace Application.Service.Repositories;

public interface IAbilityTypeRepository : IReadRepository<AbilityType, string>, IWriteRepository<AbilityType, string>
{
}
