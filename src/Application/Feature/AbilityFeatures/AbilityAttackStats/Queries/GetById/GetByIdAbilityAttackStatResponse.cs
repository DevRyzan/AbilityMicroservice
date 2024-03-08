

namespace Application.Feature.AbilityFeatures.AbilityAttackStats.Queries.GetById;

public class GetByIdAbilityAttackStatResponse
{
    public string Id { get; set; }
    public string AbilityLevelId { get; set; }
    public int AbilityAttackSpeedMultiplier { get; set; }
    public int ArmorPenetration { get; set; }
    public double AttackDamageRatio { get; set; }
    public double AttackDamageScalingStat { get; set; }
    public int AttackRange { get; set; }
    public double AttackSpeed { get; set; }
    public int AttackSpeedBonus { get; set; }
    public int AttackSpeedOnKill { get; set; }
    public double AttackSpeedScalingStat { get; set; }
    public int BaseAttackDamage { get; set; }
    public int BonusAttackDamage { get; set; }
    public int BonusAttackRange { get; set; }
    public int BonusDamageOnKill { get; set; }
    public int BonusRangeOnKill { get; set; }
    public double CriticalStrikeChance { get; set; }
    public int MagicPenetration { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
    public DateTime DeletedDate { get; set; }
}
