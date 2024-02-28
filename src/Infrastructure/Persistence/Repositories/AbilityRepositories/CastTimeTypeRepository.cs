using Application.Service.Repositories;
using Core.Persistence.Repositories;
using Core.Persistence.Repositories.Settings;
using Domain.Abilities;
using Microsoft.Extensions.Options;

namespace Persistence.Repositories.AbilityRepositories;

public class CastTimeTypeRepository : MongoDbRepositoryBase<CastTimeType, string>, ICastTimeTypeRepository
{
    public CastTimeTypeRepository(IOptions<MongoDbSettings> options) : base(options)
    {
    }
}
