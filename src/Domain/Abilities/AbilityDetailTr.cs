using Core.Persistence.Repositories;
using Domain.Enums;

namespace Domain.Abilities;

public class AbilityDetailTr : Entity<Guid>
{
    //you should take a reference AbilityId
    public LanguageCode LanguageCode { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}
