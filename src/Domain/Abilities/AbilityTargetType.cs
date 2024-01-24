using Core.Persistence.Repositories;

namespace Domain.Abilities;

public class AbilityTargetType : Entity<Guid>
{
    //public Guid  AbilityId { get; set; } you shoul take a references as ObjectId.
    public bool IsSingleTarget { get; set; }
    public bool IsAreaTarget { get; set; }
    public double Radius { get; set; }
    public string IconUrl { get; set; }
}
