using Core.Persistence.Repositories;
using Domain.Enums;

namespace Domain.Abilities;

public class AbilityEffectStat : Entity<Guid>
{
    //you should take a reference AbilityId as a ObjectId
    public double StatValue { get; set; }
    public double CoolDown { get; set; }
    public double Cost { get; set; }
    public CostType CostType { get; set; }
}
