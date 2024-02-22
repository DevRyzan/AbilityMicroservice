using Core.Persistence.Repositories;

namespace Domain.Abilities;

public class AbilityTargetType : Entity<string>
{
    public string Name { get; set; }
    public string Description { get; set; }
}
