using Domain.Enums;

namespace Application.Feature.AbilityFeatures.AbilityTargetTypeDetailEng.Commands.Update;

public class UpdateAbilityTargetTypeDetailEngCommandResponse
{
    public Guid Id { get; set; }
    public Guid AbilityTargetTypeId { get; set; }
    public LanguageCode LanguageCode { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public bool Status { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
    public DateTime DeletedDate { get; set; }
}
