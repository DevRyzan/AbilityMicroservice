

namespace Application.Feature.AbilityFeatures.AbilityTypes.Queries.GetListByActive;

public class GetListByActiveAbilityTypeQueryResponse
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
