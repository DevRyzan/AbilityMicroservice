using Domain.Enums;

namespace Application.Feature.AbilityFeatures.AbilityLevel.Queries.GetListByInActive;

public class GetListByInActiveAbilityLevelCommandResponse
{
    public string Id { get; set; }
    public string AbilityId { get; set; }
    public int LevelNumber { get; set; }
    public int Cost { get; set; }
    public double Cooldown { get; set; }
    public int Damage { get; set; }
    public int? CostIncrease { get; set; }
    public bool IsTrigger { get; set; }
    public bool IsCondition { get; set; }
    public int EffectDuration { get; set; }
    public int EffectValue { get; set; }
    public string? Code { get; set; }
    public bool Status { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public DateTime? DeletedDate { get; set; }
}
