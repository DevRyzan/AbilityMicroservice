using Core.Persistence.Repositories;

namespace Domain.Abilities;

public class AbilityEffectStat : Entity<Guid>
{
    public Guid AbilityId { get; set; }
    public int StatValue { get; set; }
    public int CoolDown { get; set; }
    public int Cost { get; set; }
    public string CostType { get; set; }
}
