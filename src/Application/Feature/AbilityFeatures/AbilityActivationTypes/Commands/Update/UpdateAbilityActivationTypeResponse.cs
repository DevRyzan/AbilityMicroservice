

namespace Application.Feature.AbilityFeatures.AbilityActivationTypes.Commands.Update;

public class UpdateAbilityActivationTypeResponse
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public bool Status { get; set; }
    public bool IsDeleted { get; set; }
    public string Code { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime DeletedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
}
