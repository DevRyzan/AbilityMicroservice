using Core.Persistence.Repositories;

namespace Domain.Abilities;

public class AbilityDamageType : Entity<Guid>
{
    public Guid AbilityId { get; set; }
    public string Icon { get; set; }
    public string Color { get; set; }
}
