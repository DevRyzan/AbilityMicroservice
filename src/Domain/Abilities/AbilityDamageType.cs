using Core.Persistence.Repositories;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Abilities;

public class AbilityDamageType : Entity<Guid>
{
    [BsonRepresentation(BsonType.ObjectId)]
    public Guid AbilityId { get; set; } 
    public string Icon { get; set; }
    public string Color { get; set; }

    [BsonIgnore]
    public Ability Ability { get; set; }
}
