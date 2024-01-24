using Core.Persistence.Repositories;
using Domain.Enums;

namespace Domain.Abilities;

public class AbilityLevelDetailEng : Entity<Guid>
{
    //You should take a references AbilityLevelId
    public LanguageCode LanguageCode { get; set; }
    public string Description { get; set; }
}
