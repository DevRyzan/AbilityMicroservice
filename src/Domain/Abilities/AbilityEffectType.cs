using Core.Persistence.Repositories;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Abilities;

public class AbilityEffectType : Entity<Guid>
{

    [BsonRepresentation(BsonType.ObjectId)]
    public Guid AbilityId { get; set; }
    public string Icon { get; set; }
    public double Duration { get; set; }
    public bool IsPositive { get; set; }
    public bool IsNegative { get; set; }

    [BsonIgnore]
    public Ability Ability { get; set; }
}
