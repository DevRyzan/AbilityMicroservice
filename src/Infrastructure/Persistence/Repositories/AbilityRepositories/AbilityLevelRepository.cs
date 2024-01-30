using Application.Service.Repositories;
using Core.Persistence.Repositories;
using Core.Persistence.Repositories.Settings;
using Domain.Abilities;
using Microsoft.Extensions.Options;

namespace Persistence.Repositories.AbilityRepositories;

public class AbilityLevelRepository : MongoDbRepositoryBase<AbilityLevel, Guid>, IAbilityLevelRepository
{
    public AbilityLevelRepository(IOptions<MongoDbSettings> options) : base(options)
    {
    }
}
