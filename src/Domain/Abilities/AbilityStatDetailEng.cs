using Core.Persistence.Repositories;
using Domain.Enums;

namespace Domain.Abilities;

public class AbilityStatDetailEng : Entity<Guid>
{
    //public Guid AbilityStatId { get; set; } you shoul take a references as a ObjectId
    public LanguageCode LanguageCode { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

}
