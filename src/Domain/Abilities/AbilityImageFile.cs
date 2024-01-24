using Core.Persistence.Repositories;

namespace Domain.Abilities;

public class AbilityImageFile : Entity<Guid>
{
    public Guid AbilityId { get; set; }
    public bool ShowCase { get; set; }
}
