using Core.Persistence.Repositories;
using Domain.Enums;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Domain.Abilities;

public class AbilityDamageTypeDetailTr : Entity<Guid>
{
    [BsonRepresentation(BsonType.ObjectId)]
    public Guid AbilityDamageTypeId { get; set; }
    public LanguageCode LanguageCode { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    [BsonIgnore]
    public AbilityDamageType AbilityDamageType { get; set; }
}
