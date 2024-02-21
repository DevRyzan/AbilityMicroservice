using Core.Persistence.Repositories.ReadRepositories;
using Core.Persistence.Repositories.WriteRepositories;
using Domain.Abilities;
using MongoDB.Bson;

namespace Application.Service.Repositories;

public interface IAbilityRepository : IReadRepository<Ability, ObjectId>, IWriteRepository<Ability, ObjectId>
{
}
