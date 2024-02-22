using Core.Persistence.Repositories;

namespace Domain.Abilities;

public class ResourceCostType : Entity<string>
{
    public string Name { get; set; }

}
