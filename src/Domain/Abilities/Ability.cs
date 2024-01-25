using Core.Persistence.Repositories;
using Domain.Enums;

namespace Domain.Abilities;

public class Ability : Entity<Guid>
{
    public decimal StatValue { get; set; }
    public decimal CollDown { get; set; }
    public decimal Cost { get; set; }
    public CostType CostType { get; set; }

}
