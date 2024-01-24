using Core.Persistence.Repositories;

namespace Domain.Abilities;

public class AbilityStat : Entity<Guid>
{
    //public Guid  AbilityId { get; set; } you shoul take a references as ObjectId.
    public double Cooldown { get; set; }
    public double Percent { get; set; }
    public double Range { get; set; }
    public double Radius { get; set; }
    public double  EnergyCost { get; set; }
}
