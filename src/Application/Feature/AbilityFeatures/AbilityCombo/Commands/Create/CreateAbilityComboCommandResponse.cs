using Domain.Enums;

namespace Application.Feature.AbilityFeatures.AbilityCombo.Commands.Create;

public class CreateAbilityComboCommandResponse
{
    public Guid Id { get; set; }
    public string AbilityId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public bool AutoLevelUp { get; set; }
    public bool IsFixedLevel { get; set; }

    public string? Code { get; set; }
    public bool Status { get; set; }
    public bool IsDeleted { get; set; }
}
