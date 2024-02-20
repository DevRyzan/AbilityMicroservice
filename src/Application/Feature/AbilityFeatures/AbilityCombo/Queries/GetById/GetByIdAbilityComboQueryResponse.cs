using Domain.Enums;

namespace Application.Feature.AbilityFeatures.AbilityCombo.Queries.GetById;

public class GetByIdAbilityComboQueryResponse
{
    public Guid Id { get; set; }
    public string AbilityId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public bool AutoLevelUp { get; set; }
    public bool IsFixedLevel { get; set; }

    public bool Status { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public DateTime? DeletedDate { get; set; }
}
