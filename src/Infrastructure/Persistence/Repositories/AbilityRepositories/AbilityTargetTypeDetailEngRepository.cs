using Application.Service.Repositories;
using Core.Persistence.Repositories;
using Core.Persistence.Repositories.Settings;
using Domain.Abilities;
using Microsoft.Extensions.Options;

namespace Persistence.Repositories.AbilityRepositories;

public class AbilityTargetTypeDetailEngRepository : MongoDbRepositoryBase<AbilityTargetTypeDetailEng, Guid>, IAbilityTargetTypeDetailEngRepository
{
    public AbilityTargetTypeDetailEngRepository(IOptions<MongoDbSettings> options) : base(options)
    {
    }
}
