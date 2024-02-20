using Domain.Enums;

namespace Application.Feature.AbilityFeatures.AbilityCombo.Dto;

public class UpdateAbilityComboDto
{
    public Guid Id { get; set; }
    public string AbilityId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public bool AutoLevelUp { get; set; }
    public bool IsFixedLevel { get; set; }
}
