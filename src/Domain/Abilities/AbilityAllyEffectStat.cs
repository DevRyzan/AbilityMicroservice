using Core.Persistence.Repositories;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Abilities;

public class AbilityAllyEffectStat : Entity<string>
{
    [BsonRepresentation(BsonType.ObjectId)]
    public string? AbilityEffectStatsId { get; set; }
    public int AbilityCooldownReductionForAllies { get; set; }
    public int AllyArmorBonus { get; set; }
    public int AllyAttackSpeedBonus { get; set; }
    public int AllyBuffRange { get; set; }
    public bool AllyCrowdControlAssistance { get; set; }
    public int AllyDebuffRange { get; set; }
    public bool AllyHealing { get; set; }
    public int AllyHealthBonus { get; set; }
    public int AllyMagicResistanceBonus { get; set; }
    public int AllyManaBonus { get; set; }
    public int AllyMovementSpeedBonus { get; set; }
    public bool AllyShielding { get; set; }
    public int BonusCrowdControlDuration { get; set; }
    public double BonusHealthRegeneration { get; set; }
    public int BonusManaRegeneration { get; set; }
    public double DamageTakenReductionForAllies { get; set; }
}
