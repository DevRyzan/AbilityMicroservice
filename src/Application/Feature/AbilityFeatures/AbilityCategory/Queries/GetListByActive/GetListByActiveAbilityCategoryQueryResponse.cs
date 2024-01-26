using Domain.Enums;

namespace Application.Feature.AbilityFeatures.AbilityCategory.Queries.GetListByActive;

public class GetListByActiveAbilityCategoryQueryResponse
{
    public string Id { get; set; }
    public string AbilityCategoryId { get; set; }
    public LanguageCode LanguageCode { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public bool Status { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime? CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public DateTime? DeletedDate { get; set; }
}
