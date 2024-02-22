using Domain.Enums;

namespace Application.Feature.AbilityFeatures.AbilityLevel.Dto;

public class UpdateAbilityLevelDto
{
    public string Id { get; set; }
    public string AbilityId { get; set; }
    public LevelNumber LevelNumber { get; set; }
    public int Cost { get; set; }
    public double Cooldown { get; set; }
    public int Damage { get; set; }
    public int? CostIncrease { get; set; }
    public bool IsTrigger { get; set; }
    public bool IsCondition { get; set; }
    public int EffectDuration { get; set; }
    public int EffectValue { get; set; }

}
