using Core.Persistence.Repositories;

namespace Domain.Abilities;

public class AbilityAndAbilityCombo : Entity<Guid>
{
    public Guid AbilityId { get; set; }
    public Guid AbilityComboId { get; set; }
}
