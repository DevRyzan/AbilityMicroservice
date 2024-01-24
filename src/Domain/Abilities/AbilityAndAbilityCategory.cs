using Core.Persistence.Repositories;

namespace Domain.Abilities;

public class AbilityAndAbilityCategory : Entity<Guid>
{
    public Guid AbilityId { get; set; }
    public Guid AbilityCategoryId { get; set; }
}
