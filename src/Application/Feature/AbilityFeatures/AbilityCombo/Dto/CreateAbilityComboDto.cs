using Domain.Enums;

namespace Application.Feature.AbilityFeatures.AbilityCombo.Dto;

public class CreateAbilityComboDto
{
    public string AbilityId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public bool AutoLevelUp { get; set; }
    public bool IsFixedLevel { get; set; }
}
