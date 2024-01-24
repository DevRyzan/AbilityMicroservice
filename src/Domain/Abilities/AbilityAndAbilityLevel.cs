using Core.Persistence.Repositories;

namespace Domain.Abilities;

public class AbilityAndAbilityLevel : Entity<Guid>
{
    public Guid AbilityId { get; set; }
    public Guid AbilityLevelId { get; set; }
}
