using Core.Persistence.Repositories;

namespace Domain.Abilities;

public class AbilityLevelDetailEng : Entity<Guid>
{
    public Guid AbilityId { get; set; }
    public string LanguageCode { get; set; }
    public string Description { get; set; }
}
