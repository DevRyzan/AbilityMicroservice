using Core.Persistence.Repositories;
using Domain.Enums;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Abilities;

public class AbilityTargetTypeDetailEng : Entity<Guid>
{
    [BsonRepresentation(BsonType.String)]
    public Guid AbilityTargetTypeId { get; set; } 
    public LanguageCode LanguageCode { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    [BsonIgnore]
    public AbilityTargetType AbilityTargetType { get; set; }
}
