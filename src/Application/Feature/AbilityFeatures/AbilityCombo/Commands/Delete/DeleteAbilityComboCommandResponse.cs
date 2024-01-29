using Domain.Enums;

namespace Application.Feature.AbilityFeatures.AbilityCombo.Commands.Delete;

public class DeleteAbilityComboCommandResponse
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
