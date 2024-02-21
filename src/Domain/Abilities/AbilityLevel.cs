using Core.Persistence.Repositories;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;


namespace Domain.Abilities;

public class AbilityLevel : Entity<string>
{
    [BsonRepresentation(BsonType.ObjectId)]
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

}
