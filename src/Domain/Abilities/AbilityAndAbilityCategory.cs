using Core.Persistence.Repositories;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Abilities;

public class AbilityAndAbilityCategory : Entity<Guid>
{
    [BsonRepresentation(BsonType.ObjectId)]
    public Guid AbilityId { get; set; }

    [BsonRepresentation(BsonType.ObjectId)]
    public Guid AbilityCategoryId { get; set; }


    [BsonIgnore]
    public Ability Ability { get; set; }
    [BsonIgnore]
    public AbilityCategory AbilityCategory { get; set; }
}
