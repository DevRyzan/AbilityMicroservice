﻿using Application.Service.AbilityServices.AbilityActivationTypeService;
using Application.Service.AbilityServices.AbilityAffectUnitService;
using Application.Service.AbilityServices.AbilityAllyEffectStatService;
using Application.Service.AbilityServices.AbilityAttackStatService;
using Application.Service.AbilityServices.AbilityComboService;
using Application.Service.AbilityServices.AbilityDamageTypeService;
using Application.Service.AbilityServices.AbilityEffectDisableTypeService;
using Application.Service.AbilityServices.AbilityEffectService;
using Application.Service.AbilityServices.AbilityEffectStatService;
using Application.Service.AbilityServices.AbilityEffectTypeService;
using Application.Service.AbilityServices.AbilityEnemyEffectStatService;
using Application.Service.AbilityServices.AbilityLevelService;
using Application.Service.AbilityServices.AbilitySelfEffectStatService;
using Application.Service.AbilityServices.AbilityService;
using Application.Service.AbilityServices.AbilityTargetTypeService;
using Application.Service.AbilityServices.AbilityTypeService;
using Application.Service.AbilityServices.CastTimeTypeService;
using Application.Service.AbilityServices.ResourceCostTypeService;
using Core.Application;
using Core.Application.Caching;
using Core.Application.Generator;
using Core.Application.Logging;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Validation;
using Core.Application.Transaction;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;


namespace Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {

        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            configuration.AddOpenBehavior(typeof(AuthorizationBehavior<,>));
            configuration.AddOpenBehavior(typeof(CachingBehavior<,>));
            configuration.AddOpenBehavior(typeof(CacheRemovingBehavior<,>));
            configuration.AddOpenBehavior(typeof(LoggingBehavior<,>));
            configuration.AddOpenBehavior(typeof(RequestValidationBehavior<,>));
            configuration.AddOpenBehavior(typeof(TransactionScopeBehavior<,>));
            //configuration.RegisterServicesFromAssemblyContaining<>();
        });

        //services.AddMemoryCache();

        services.AddSubClassesOfType(Assembly.GetExecutingAssembly(), typeof(BaseBusinessRules));

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());


        services.AddSingleton<IRandomCodeGenerator, RandomCodeGenerator>();


        services.AddScoped<IAbilityService, AbilityManager>();
        services.AddScoped<IAbilityComboService, AbilityComboManager>();
        services.AddScoped<IAbilityLevelService, AbilityLevelManager>();
        services.AddScoped<IAbilityTargetTypeService, AbilityTargetTypeManager>();
        services.AddScoped<IResourceCostTypeService, ResourceCostTypeManager>();
        services.AddScoped<ICastTimeTypeService, CastTimeTypeManager>();
        services.AddScoped<IAbilityTypeService, AbilityTypeManager>();
        services.AddScoped<IAbilityEffectTypeService, AbilityEffectTypeManager>();
        services.AddScoped<IAbilityEffectDisableTypeService, AbilityEffectDisableTypeManager>();
        services.AddScoped<IAbilityDamageTypeService, AbilityDamageTypeManager>();
        services.AddScoped<IAbilityAffectUnitService, AbilityAffectUnitManager>();
        services.AddScoped<IAbilityActivationTypeService, AbilityActivationTypeManager>();
        services.AddScoped<IAbilityAllyEffectStatService, AbilityAllyEffectStatManager>();
        services.AddScoped<IAbilityAttackStatService, AbilityAttackStatManager>();
        services.AddScoped<IAbilityEffectService, AbilityEffectManager>();
        services.AddScoped<IAbilityEffectStatService, AbilityEffectStatManager>();
        services.AddScoped<IAbilityEnemyEffectStatService, AbilityEnemyEffectStatManager>();
        services.AddScoped<IAbilitySelfEffectStatService, AbilitySelfEffectStatManager>();





        return services;
    }
    public static IServiceCollection AddSubClassesOfType(this IServiceCollection services, Assembly assembly, Type type, Func<IServiceCollection, Type, IServiceCollection>? addWithLifeCycle = null)
    {
        var types = assembly.GetTypes().Where(t => t.IsSubclassOf(type) && type != t).ToList();
        foreach (var item in types)
        {
            if (addWithLifeCycle == null)
            {
                services.AddScoped(item);
            }
            else
            {
                addWithLifeCycle(services, type);
            }
        }
        return services;
    }
}
