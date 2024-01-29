using Domain.Enums;

namespace Application.Feature.AbilityFeatures.AbilityCombo.Dto;

public class UpdateAbilityComboDto
{
    public Guid Id { get; set; }
    public ComboNumber ComboNumber { get; set; }
    public string IconUrl { get; set; }
}
