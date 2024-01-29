using Domain.Enums;

namespace Application.Feature.AbilityFeatures.AbilityCombo.Queries.GetListByInActive;

public class GetListByInActiveAbilityComboQueryResponse
{
    public Guid Id { get; set; }
    public ComboNumber ComboNumber { get; set; }
    public string IconUrl { get; set; }
    public bool Status { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public DateTime? DeletedDate { get; set; }
}
