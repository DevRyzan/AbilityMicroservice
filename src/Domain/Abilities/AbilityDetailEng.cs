using Core.Persistence.Repositories;

namespace Domain.Abilities;

public class AbilityDetailEng : Entity<Guid>
{
    public Guid AbilityId { get; set; }
    public string LanguageCode { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}
