

namespace Application.Feature.AbilityFeatures.AbilityActivationTypes.Commands.Create;

public class CreateAbilityActivationTypeResponse
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public bool Status { get; set; }
    public bool IsDeleted { get; set; }
    public string Code { get; set; }
}
