using Core.Persistence.Repositories;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Abilities;

public class AbilityImageFile : Entity<Guid>
{
    [BsonRepresentation(BsonType.ObjectId)]
    public Guid AbilityId { get; set; } 
    public bool ShowCase { get; set; }

    [BsonIgnore]
    public Ability Ability { get; set; }
}
