namespace Application.Feature.AbilityFeatures.Ability.Commands.Create;

public class CreateAbilityCommandResponse
{
    public Guid Id { get; set; }
    //public Guid HeroId { get; set; }
    //public Guid AbilityLevelId { get; set; }
    //public Guid AbilityComboId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string IconUrl { get; set; }
    public bool Status { get; set; }
    public DateTime CreatedDate { get; set; }
}
