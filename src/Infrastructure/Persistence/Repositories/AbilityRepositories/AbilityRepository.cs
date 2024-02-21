using Application.Service.Repositories;
using Core.Persistence.Repositories;
using Core.Persistence.Repositories.Settings;
using Domain.Abilities;
using Microsoft.Extensions.Options;
using MongoDB.Bson;

namespace Persistence.Repositories.AbilityRepositories;

public class AbilityRepository : MongoDbRepositoryBase<Ability, ObjectId>, IAbilityRepository
{
    public AbilityRepository(IOptions<MongoDbSettings> options) : base(options)
    {
    }
}
