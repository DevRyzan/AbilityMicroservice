using Core.Persistence.Repositories;
using Domain.Enums;

namespace Domain.Abilities;

public class AbilityCategoryDetailEng : Entity<Guid>
{
    //public Guid AbilityCategoryId { get; set; } you should take a references as AbilityCategoryId as a ObjectId()
    public LanguageCode LanguageCode { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}
