using Core.Persistence.Repositories;

namespace Domain.Abilities;

public class CastTimeType : Entity<string>
{
    public string Name { get; set; }
    public string Description { get; set; }
}
