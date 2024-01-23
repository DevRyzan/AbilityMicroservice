using Application.Service.Repositories;
using Core.Persistence.Repositories;
using Core.Persistence.Repositories.Settings;
using Domain.Abilities;
using Microsoft.Extensions.Options;

namespace Persistence.Repositories.AbilityRepositories;

public class AbilityCategoryRepository : MongoDbRepositoryBase<AbilityCategory, Guid>, IAbilityCategoryRepository
{
    public AbilityCategoryRepository(IOptions<MongoDbSettings> options) : base(options)
    {
    }
}

