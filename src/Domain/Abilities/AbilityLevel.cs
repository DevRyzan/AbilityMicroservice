using Core.Persistence.Repositories;

namespace Domain.Abilities;

public class AbilityLevel : Entity<Guid>
{
    public int LevelNumber { get; set; }
    public int Duration { get; set; }
    public int Range { get; set; }
    public int EnergyCost { get; set; }
    public string IconUrl { get; set; }
}
