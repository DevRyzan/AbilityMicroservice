using Core.Persistence.Repositories;
using Domain.Enums;

namespace Domain.Abilities;

public class AbilityLevel : Entity<Guid>
{
    public LevelNumber LevelNumber { get; set; }
    public double Duration { get; set; }
    public double Range { get; set; }
    public double EnergyCost { get; set; }
    public string IconUrl { get; set; }
}
