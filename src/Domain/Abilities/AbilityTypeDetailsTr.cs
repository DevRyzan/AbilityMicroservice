using Core.Persistence.Repositories;
using Domain.Enums;

namespace Domain.Abilities;

public class AbilityTypeDetailsTr : Entity<Guid>
{
    //public Guid AbilityTypeId { get; set; } you shouldtake a ref as a objectId()
    public LanguageCode LanguageCode { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

}
