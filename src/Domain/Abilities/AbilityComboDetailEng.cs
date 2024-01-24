using Core.Persistence.Repositories;
using Domain.Enums;

namespace Domain.Abilities;

public class AbilityComboDetailEng : Entity<Guid>
{
    //You should take a AbilityComboId references as a ObjectId
    public LanguageCode LanguageCode { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string ComboType { get; set; } // ComboType could be enum may be later.
}
