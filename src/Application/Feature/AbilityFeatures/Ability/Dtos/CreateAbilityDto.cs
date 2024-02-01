namespace Application.Feature.AbilityFeatures.Ability.Dtos;

public class CreateAbilityDto
{
    public Guid HeroId { get; set; }
    public List<Guid> AbilityLevelIds { get; set; }
    public Guid AbilityComboId { get; set; }
}
