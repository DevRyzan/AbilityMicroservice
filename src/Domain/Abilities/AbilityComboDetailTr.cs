using Core.Persistence.Repositories;

namespace Domain.Abilities;

public class AbilityComboDetailTr : Entity<Guid>
{
    public Guid AbilityComboId { get; set; }
    public string LanguageCode { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string ComboType { get; set; }
}
