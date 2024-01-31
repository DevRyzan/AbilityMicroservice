namespace Application.Feature.AbilityFeatures.Ability.Queries.GetById;

public class GetByIdAbilityQueryResponse
{
    public Guid Id { get; set; }
    public Guid HeroId { get; set; }
    public Guid AbilityComboId { get; set; }
    public bool Status { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
    public DateTime DeletedDate { get; set; }
}
