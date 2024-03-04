
using Core.Persistence.Repositories;


namespace Domain.Abilities;

public class AbilityEffectDisableType : Entity<string>
{
    public string Name { get; set; }
    public string Description { get; set; }
}
