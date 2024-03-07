using Application.Service.Repositories;
using Core.Persistence.Repositories;
using Core.Persistence.Repositories.Settings;
using Domain.Abilities;
using Microsoft.Extensions.Options;

namespace Persistence.Repositories.AbilityRepositories;

public class AbilityEffectRepository : MongoDbRepositoryBase<AbilityEffect, string>, IAbilityEffectRepository
{
    public AbilityEffectRepository(IOptions<MongoDbSettings> options) : base(options)
    {
    }
}
