using Core.Persistence.Repositories;
using Domain.Enums;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Domain.Abilities;

public class AbilityLevelDetailTr : Entity<Guid>
{
    [BsonRepresentation(BsonType.ObjectId)]
    public AbilityLevel AbilityLevelId { get; set; }
    public LanguageCode LanguageCode { get; set; }
    public string Description { get; set; }

    [BsonIgnore]
    public AbilityLevel AbilityLevel { get; set; }
}
