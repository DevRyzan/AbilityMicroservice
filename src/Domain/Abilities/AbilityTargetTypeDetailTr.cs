using Core.Persistence.Repositories;
using Domain.Enums;

namespace Domain.Abilities;

public class AbilityTargetTypeDetailTr : Entity<Guid>
{
    //public Guid AbilityTargetTypeId { get; set; } you should take a references objectId
    public LanguageCode LanguageCode { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}
