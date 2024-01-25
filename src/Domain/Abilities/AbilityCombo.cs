using Core.Persistence.Repositories;
using Domain.Enums;

namespace Domain.Abilities;

public class AbilityCombo : Entity<Guid>
{
    public ComboNumber ComboNumber { get; set; }
    public string IconUrl { get; set; }
}
