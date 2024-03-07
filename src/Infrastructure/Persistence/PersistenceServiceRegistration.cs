using Application.Service.Repositories;
using Core.Persistence.Repositories.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Context;
using Persistence.Repositories.AbilityRepositories;

namespace Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        return services
            .Configure<MongoDbSettings>(options =>
            {
                options.ConnectionString = configuration.GetSection(nameof(MongoDbSettings) + ":" + MongoDbSettings.ConnectionStringValue).Value;
                options.Database = configuration.GetSection(nameof(MongoDbSettings) + ":" + MongoDbSettings.DatabaseValue).Value;
            })
            .AddTransient<BaseDbContext>()
            .AddScoped<IAbilityRepository, AbilityRepository>()
            .AddScoped<IAbilityComboRepository, AbilityComboRepository>()
            .AddScoped<IAbilityLevelRepository, AbilityLevelRepository>()
            .AddScoped<IAbilityTargetTypeRepository, AbilityTargetTypeRepository>()
            .AddScoped<IResourceCostTypeRepository, ResourceCostTypeRepository>()
            .AddScoped<ICastTimeTypeRepository, CastTimeTypeRepository>()
            .AddScoped<IAbilityTypeRepository, AbilityTypeRepository>()
            .AddScoped<IAbilityEffectTypeRepository, AbilityEffectTypeRepository>()
            .AddScoped<IAbilityEffectDisableTypeRepository, AbilityEffectDisableTypeRepository>()
            .AddScoped<IAbilityDamageTypeRepository, AbilityDamageTypeRepository>()
            .AddScoped<IAbilityAffectUnitRepository, AbilityAffectUnitRepository>()
            .AddScoped<IAbilityActivationTypeRepository, AbilityActivationTypeRepository>()
            .AddScoped<IAbilityAttackStatRepository, AbilityAttackStatRepository>()
            .AddScoped<IAbilityEffectRepository, AbilityEffectRepository>()
            .AddScoped<IAbilityEffectStatRepository, AbilityEffectStatRepository>()
            .AddScoped<IAbilityEnemyEffectStatRepository, AbilityEnemyEffectStatRepository>()
            .AddScoped<IAbilitySelfEffectStatRepository, AbilitySelfEffectStatRepository>()
            .AddScoped<IAbilityAllyEffectStatRepository, AbilityAllyEffectStatRepository>();

    }
}