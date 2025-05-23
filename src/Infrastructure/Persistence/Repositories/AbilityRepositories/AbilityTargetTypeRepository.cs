﻿using Application.Service.Repositories;
using Core.Persistence.Repositories;
using Core.Persistence.Repositories.Settings;
using Domain.Abilities;
using Microsoft.Extensions.Options;

namespace Persistence.Repositories.AbilityRepositories;

public class AbilityTargetTypeRepository : MongoDbRepositoryBase<AbilityTargetType, string>, IAbilityTargetTypeRepository
{
    public AbilityTargetTypeRepository(IOptions<MongoDbSettings> options) : base(options)
    {
    }
}
