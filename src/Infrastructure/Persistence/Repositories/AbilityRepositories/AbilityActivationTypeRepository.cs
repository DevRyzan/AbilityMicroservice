using Application.Service.Repositories;
using Core.Persistence.Repositories;
using Core.Persistence.Repositories.Settings;
using Domain.Abilities;
using Microsoft.Extensions.Options;


namespace Persistence.Repositories.AbilityRepositories;

public class AbilityActivationTypeRepository : MongoDbRepositoryBase<AbilityActivationType, string>, IAbilityActivationTypeRepository
{
    public AbilityActivationTypeRepository(IOptions<MongoDbSettings> options) : base(options)
    {
    }
}
