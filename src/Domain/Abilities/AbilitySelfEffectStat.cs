using Core.Persistence.Repositories;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace Domain.Abilities;

public class AbilitySelfEffectStat : Entity<string>
{
    [BsonRepresentation(BsonType.ObjectId)]
    public string AbilityEffectStatsId { get; set; }
    public bool AreaOfEffect { get; set; }
    public bool DamageReflection { get; set; }
    public bool DamageSoakingAbility { get; set; }
    public bool DisruptAbilityCasts { get; set; }
    public bool SelfShielding { get; set; }
    public int TauntDuration { get; set; }
    public bool TerrainCreation { get; set; }
    public int ThreatGeneration { get; set; }
}
