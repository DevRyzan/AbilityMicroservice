using MongoDB.Bson;

namespace Application.Feature.AbilityFeatures.Ability.Commands.Create;

public class CreateAbilityCommandResponse
{
    public ObjectId Id { get; set; }
    public ObjectId HeroId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public ObjectId AbilityTypeId { get; set; }
    public ObjectId TargetTypeId { get; set; }
    public ObjectId DamageTypeId { get; set; }
    public ObjectId AffectUnıtId { get; set; }
    public ObjectId CastTimeTypeId { get; set; }
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
