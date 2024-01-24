using Core.Persistence.Repositories;

namespace Domain.Abilities;

public class AbilityCombo : Entity<Guid>
{
    public Guid ComboNumberId { get; set; }
    public string IconUrl { get; set; }
}
