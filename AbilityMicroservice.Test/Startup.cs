using AbilityMicroservice.Test.DependencyModels;
using Microsoft.Extensions.DependencyInjection;

namespace AbilityMicroservice.Test;

public sealed class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddAbilityServices();
    }
}
