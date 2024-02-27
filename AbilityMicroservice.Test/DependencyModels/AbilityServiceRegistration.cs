using AbilityMicroservice.Test.Mocks.FakeDatas;
using Application.Feature.AbilityFeatures.Ability.Commands.ChangeStatus;
using Microsoft.Extensions.DependencyInjection;

namespace AbilityMicroservice.Test.DependencyModels;

public static class AbilityServiceRegistration
{
    public static void AddAbilityServices(this IServiceCollection services)
    {
        services.AddTransient<AbilityFakeData>();
        services.AddTransient<ChangeStatusAbilityCommandHandler>();
    }
}
