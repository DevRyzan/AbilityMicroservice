using Core.Persistence.Repositories;
using Domain.Enums;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Domain.Abilities;

public class AbilityCategoryDetailEng : Entity<Guid>
{
    [BsonRepresentation(BsonType.String)]
    public Guid AbilityCategoryId { get; set; }
    public LanguageCode LanguageCode { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    [BsonIgnore]
    public AbilityCategory AbilityCategory { get; set; }
}
