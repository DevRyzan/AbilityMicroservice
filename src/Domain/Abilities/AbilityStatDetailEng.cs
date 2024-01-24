using Core.Persistence.Repositories;

namespace Domain.Abilities;

public class AbilityStatDetailEng : Entity<Guid>
{
    public Guid AbilityStatId { get; set; }
    public string LanguageCode { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

}
