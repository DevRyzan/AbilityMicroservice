namespace Application.Feature.AbilityFeatures.Ability.Queries.GetListByInActive;

public class GetListByInActiveAbilityQueryResponse
{
    public Guid Id { get; set; }
    public Guid HeroId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string AbilityTypeId { get; set; }
    public string TargetTypeId { get; set; }
    public string DamageTypeId { get; set; }
    public string AffectUnıtId { get; set; }
    public string CastTimeTypeId { get; set; }
    public double? CastTimeTypeValue { get; set; }
    public double Cooldown { get; set; }
    public double Radius { get; set; }
    public double Damage { get; set; }
    public bool IsCondition { get; set; }
    public bool IsTrigger { get; set; }
    public bool IsHaveCombo { get; set; }
    public int Cost { get; set; }
    public bool IsTargeted { get; set; }
    public bool IsBlockable { get; set; }
    public bool IsCharging { get; set; }
    public bool IsHaveDisable { get; set; }
    public int? AbilityLevelUpgradeFrequency { get; set; }
    public string Code { get; set; }
    public bool Status { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
    public DateTime DeletedDate { get; set; }
}
