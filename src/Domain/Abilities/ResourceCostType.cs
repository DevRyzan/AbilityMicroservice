using Core.Persistence.Repositories;

namespace Domain.Abilities;

public class ResourceCostType : Entity<Guid>
{
    public string Name { get; set; }

}
