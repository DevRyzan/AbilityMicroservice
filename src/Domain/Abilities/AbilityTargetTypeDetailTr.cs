using Core.Persistence.Repositories;

namespace Domain.Abilities;

public class AbilityTargetTypeDetailTr : Entity<Guid>
{
    public Guid AbilityTargetTypeId { get; set; }
    public string LanguageCode { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}
