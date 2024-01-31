using Core.Persistence.Repositories;
using Domain.Enums;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Abilities;

public class AbilityLevelDetailEng : Entity<Guid>
{
    [BsonRepresentation(BsonType.String)]
    public Guid AbilityLevelId { get; set; }
    public LanguageCode LanguageCode { get; set; }
    public string Description { get; set; }

    [BsonIgnore]
    public AbilityLevel AbilityLevel { get; set; }
}
