using Core.Persistence.Repositories;
using Domain.Enums;

namespace Domain.Abilities;

public class AbilityEffectStatDetailTr : Entity<Guid>
{
    //public Guid AbilityEffectStatId { get; set; } // take a references as a ObjectId
    public LanguageCode LanguageCode { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}
