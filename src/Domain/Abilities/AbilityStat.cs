using Core.Persistence.Repositories;

namespace Domain.Abilities;

public class AbilityStat : Entity<Guid>
{
    public Guid  AbilityId { get; set; }
    public int Cooldown { get; set; }
    public int Percent { get; set; }
    public int Range { get; set; }
    public int Radius { get; set; }
    public int EnergyCost { get; set; }
}
