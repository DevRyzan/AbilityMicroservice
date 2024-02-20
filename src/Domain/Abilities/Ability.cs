using Core.Persistence.Repositories;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Abilities;

public class Ability : Entity<Guid>
{
    [BsonRepresentation(BsonType.ObjectId)]
    public string HeroId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    [BsonRepresentation(BsonType.ObjectId)]
    public string AbilityTypeId { get; set; }

    [BsonRepresentation(BsonType.ObjectId)]
    public string TargetTypeId { get; set; }

    [BsonRepresentation(BsonType.ObjectId)]
    public string DamageTypeId { get; set; }

    [BsonRepresentation(BsonType.ObjectId)]
    public string AffectUnıtId { get; set; }

    [BsonRepresentation(BsonType.ObjectId)]
    public string CastTimeTypeId { get; set; }

    public double? CastTimeTypeValue { get; set; }
    public double Cooldown { get; set; }
    public double Radius { get; set; }
    public double Damage { get; set; }
    public bool IsCondition { get; set; }
    public bool IsTrigger { get; set; }
    public bool IsHaveCombo { get; set; }
    public bool IsTargeted { get; set; }
    public bool IsBlockable { get; set; }
    public bool IsCharging { get; set; }
    public bool IsHaveDisable { get; set; }
    public int? AbilityLevelUpgradeFrequency { get; set; }
    public int Cost { get; set; }

}
