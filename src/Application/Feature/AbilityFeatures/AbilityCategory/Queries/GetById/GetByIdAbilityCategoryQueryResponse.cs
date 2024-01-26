namespace Application.Feature.AbilityFeatures.AbilityCategory.Queries.GetById;

public class GetByIdAbilityCategoryQueryResponse
{
    public Guid Id { get; set; }
    public Guid AbilityCategoryDetailEngId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public bool Status { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime? CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public DateTime? DeletedDate { get; set; }
}
