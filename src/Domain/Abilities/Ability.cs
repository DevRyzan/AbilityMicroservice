using Core.Persistence.Repositories;

namespace Domain.Abilities;

public class Ability : Entity<Guid>
{
    //you should take a references as a ObjecytId for HeroId,AbilityLevelId and AbilityComboId.
    public string IconUrl { get; set; }

}
