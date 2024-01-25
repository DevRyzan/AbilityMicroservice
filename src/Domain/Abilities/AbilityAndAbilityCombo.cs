using Core.Persistence.Repositories;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Abilities;

public class AbilityAndAbilityCombo : Entity<Guid>
{
    [BsonRepresentation(BsonType.ObjectId)]
    public Guid AbilityId { get; set; }

    [BsonRepresentation(BsonType.ObjectId)]
    public Guid AbilityComboId { get; set; } 


    [BsonIgnore]
    public Ability Ability { get; set; }
    [BsonIgnore]
    public AbilityCombo AbilityCombo { get; set; }
}
