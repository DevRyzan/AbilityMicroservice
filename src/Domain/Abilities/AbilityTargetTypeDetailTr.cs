using Core.Persistence.Repositories;
using Domain.Enums;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Domain.Abilities;

public class AbilityTargetTypeDetailTr : Entity<Guid>
{
    [BsonRepresentation(BsonType.ObjectId)]
    public Guid AbilityTargetTypeId { get; set; }
    public LanguageCode LanguageCode { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    [BsonIgnore]
    public AbilityTargetType AbilityTargetType { get; set; }
}
