using Core.Persistence.Repositories;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Abilities;

public class AbilityTargetType : Entity<Guid>
{
    [BsonRepresentation(BsonType.ObjectId)]
    public Guid AbilityTId { get; set; }
    public bool IsSingleTarget { get; set; }
    public bool IsAreaTarget { get; set; }
    public double Radius { get; set; }
    public string IconUrl { get; set; }

    [BsonIgnore]
    public Ability Ability { get; set; }
}
