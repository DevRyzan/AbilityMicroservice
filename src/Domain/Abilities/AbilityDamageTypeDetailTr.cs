using Core.Persistence.Repositories;
using Domain.Enums;

namespace Domain.Abilities;

public class AbilityDamageTypeDetailTr : Entity<Guid>
{
    //public Guid AbilityDamageTypeId { get; set; } take a references as a ObjectId()
    public LanguageCode LanguageCode { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}
