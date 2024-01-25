using Core.Persistence.Repositories;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Abilities;

public class AbilityAndAbilityLevel : Entity<Guid>
{
    [BsonRepresentation(BsonType.ObjectId)]
    public Guid AbilityId { get; set; }
    [BsonRepresentation(BsonType.ObjectId)]
    public Guid AbilityLevelId { get; set; }


    [BsonIgnore]
    public Ability Ability { get; set; }
    [BsonIgnore]
    public AbilityLevel AbilityLevel { get; set; }
}
