

namespace Application.Feature.AbilityFeatures.AbilityEffectStats.Queries.GetListByActive;

public class GetByActiveListAbilityEffectStatResponse
{
    public string Id { get; set; }
    public string AbilityEffectId { get; set; }
    public int CrowdControlDuration { get; set; }
    public int CrowdControlRange { get; set; }
    public int CrowdControlResistance { get; set; }
    public int DamageReductionPercentage { get; set; }
    public int DisengageAbilityRange { get; set; }
    public int EngageAbilityRange { get; set; }
    public int ExperienceGainMultiplier { get; set; }
    public int GoldIncomeMultiplier { get; set; }
    public int HealAmount { get; set; }
    public int PeelAbilityRange { get; set; }
    public int ShieldAmount { get; set; }
    public int VisionRadiusBonus { get; set; }

    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
    public DateTime DeletedDate { get; set; }
}
