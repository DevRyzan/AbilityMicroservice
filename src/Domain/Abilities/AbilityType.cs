using Core.Persistence.Repositories;

namespace Domain.Abilities;

public class AbilityType : Entity<Guid>
{
    public Guid AbilityId { get; set; }
    public string Icon { get; set; }
    public bool IsPassive { get; set; }
    public bool IsActive { get; set; }
    public bool IsUltimate { get; set; }
}
