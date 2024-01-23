namespace Application.Feature.AbilityFeatures.AbilityCategory.Commands.Create;

public class CreatedAbilityCategoryCommandResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public bool Status { get; set; }
}
