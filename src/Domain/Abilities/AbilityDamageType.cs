using Core.Persistence.Repositories;



namespace Domain.Abilities;

public class AbilityDamageType : Entity<Guid>
{
    public string Name { get; set; }
    public string Description { get; set; }

}
