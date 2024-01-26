using Core.Persistence.Repositories.ReadRepositories;
using Core.Persistence.Repositories.WriteRepositories;
using Domain.Abilities;

namespace Application.Service.Repositories;

public interface IAbilityCategoryDetailEngRepository : IReadRepository<AbilityCategoryDetailEng, Guid>, IWriteRepository<AbilityCategoryDetailEng, Guid>
{
}
