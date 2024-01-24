using Core.Persistence.Repositories;

namespace Domain.Abilities;

public class AbilityTypeDetailsTr : Entity<Guid>
{
    public Guid AbilityTypeId { get; set; }
    public string LanguageCode { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

}
