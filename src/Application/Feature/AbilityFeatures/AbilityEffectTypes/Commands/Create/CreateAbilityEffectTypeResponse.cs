

namespace Application.Feature.AbilityFeatures.AbilityEffectTypes.Commands.Create;

public class CreateAbilityEffectTypeResponse
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public bool Status { get; set; }
    public bool IsDeleted { get; set; }
    public string Code { get; set; }
}
