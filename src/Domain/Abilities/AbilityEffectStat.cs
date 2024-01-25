using Core.Persistence.Repositories;
using Domain.Enums;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Abilities;

public class AbilityEffectStat : Entity<Guid>
{
    [BsonRepresentation(BsonType.ObjectId)]
    public Guid AbilityId { get; set; }
    public double StatValue { get; set; }
    public double CoolDown { get; set; }
    public double Cost { get; set; }
    public CostType CostType { get; set; }

    [BsonIgnore]
    public Ability Ability { get; set; }
}
