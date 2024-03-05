using Core.Persistence.Repositories.ReadRepositories;
using Core.Persistence.Repositories.WriteRepositories;
using Domain.Abilities;


namespace Application.Service.Repositories;

public interface IAbilityDamageTypeRepository : IReadRepository<AbilityDamageType, string>, IWriteRepository<AbilityDamageType, string>
{
}
