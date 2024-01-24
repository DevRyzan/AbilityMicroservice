using Core.Persistence.Repositories;

namespace Domain.Abilities;

public class AbilityTargetType : Entity<Guid>
{
    public Guid AbilityId { get; set; }
    public bool IsSingleTarget { get; set; }
    public bool IsAreaTarget { get; set; }
    public int Radius { get; set; }
    public string IconUrl { get; set; }
}
