

using Core.Persistence.Repositories;

namespace Domain.Abilities;

public class AbilityEffectType : Entity<string>
{
    public string Name { get; set; }
    public string Description { get; set; }
}
