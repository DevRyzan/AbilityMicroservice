using Core.Persistence.Repositories;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Abilities;

public class AbilityType : Entity<Guid>
{
    [BsonRepresentation(BsonType.ObjectId)]
    public Guid AbilityId { get; set; }
    public string Icon { get; set; }
    public bool IsPassive { get; set; }
    public bool IsActive { get; set; }
    public bool IsUltimate { get; set; }

    [BsonIgnore]
    public Ability Ability { get; set; }
}
