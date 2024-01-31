namespace Application.Feature.AbilityFeatures.Ability.Commands.Delete;

public class DeleteAbilityCommandResponse
{
    public Guid Id { get; set; }
    public Guid HeroId { get; set; }
    public Guid AbilityComboId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string IconUrl { get; set; }
    public bool Status { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
    public DateTime DeletedDate { get; set; }
}
