

using Core.Persistence.Repositories;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Domain.Abilities;

public class AbilityCombo : Entity<Guid>
{
    [BsonRepresentation(BsonType.ObjectId)]
    public string AbilityId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public bool AutoLevelUp { get; set; }
    public bool IsFixedLevel { get; set; }






}
