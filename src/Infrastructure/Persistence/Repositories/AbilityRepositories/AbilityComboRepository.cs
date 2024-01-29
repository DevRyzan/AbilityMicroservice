using Application.Service.Repositories;
using Core.Persistence.Repositories;
using Core.Persistence.Repositories.Settings;
using Domain.Abilities;
using Microsoft.Extensions.Options;

namespace Persistence.Repositories.AbilityRepositories;

public class AbilityComboRepository : MongoDbRepositoryBase<AbilityCombo, Guid>, IAbilityComboRepository
{
    public AbilityComboRepository(IOptions<MongoDbSettings> options) : base(options)
    {
    }
}
