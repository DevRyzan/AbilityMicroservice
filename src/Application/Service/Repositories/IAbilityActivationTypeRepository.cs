using Core.Persistence.Repositories.ReadRepositories;
using Core.Persistence.Repositories.WriteRepositories;
using Domain.Abilities;


namespace Application.Service.Repositories;

public interface IAbilityActivationTypeRepository : IReadRepository<AbilityActivationType, string>, IWriteRepository<AbilityActivationType, string>
{
}
