using Domain.Enums;

namespace Application.Feature.AbilityFeatures.AbilityLevelDetailEng.Queries.GetListByInActive;

public class GetListByInActiveAbilityLevelDetailEngCommandResponse
{
    public Guid Id { get; set; }
    public Guid AbilityLevelId { get; set; }
    public LanguageCode LanguageCode { get; set; }
    public string Description { get; set; }
    public string? Code { get; set; }
    public bool Status { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public DateTime? DeletedDate { get; set; }
}
