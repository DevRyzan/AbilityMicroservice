using Core.Persistence.Repositories.ReadRepositories;
using Core.Persistence.Repositories.WriteRepositories;
using Domain.Abilities;

namespace Application.Service.Repositories;

public interface IAbilityComboRepository :  IReadRepository<AbilityCombo, Guid>, IWriteRepository<AbilityCombo, Guid>
{
}
