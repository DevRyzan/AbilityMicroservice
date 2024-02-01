using Core.Persistence.Repositories;
using Domain.Enums;

namespace Domain.Abilities;

public class Ability : Entity<Guid>
{
    public Guid HeroId { get; set; }
    public List<AbilityLevel> AbilityLevels { get; set; }
    public AbilityCombo AbilityCombo { get; set; }

}
