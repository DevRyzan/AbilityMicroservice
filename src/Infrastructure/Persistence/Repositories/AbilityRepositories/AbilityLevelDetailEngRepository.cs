using Application.Service.Repositories;
using Core.Persistence.Repositories;
using Core.Persistence.Repositories.Settings;
using Domain.Abilities;
using Microsoft.Extensions.Options;

namespace Persistence.Repositories.AbilityRepositories;

public class AbilityLevelDetailEngRepository : MongoDbRepositoryBase<AbilityLevelDetailEng, Guid>, IAbilityLevelDetailEngRepository
{
    public AbilityLevelDetailEngRepository(IOptions<MongoDbSettings> options) : base(options)
    {
    }
}
