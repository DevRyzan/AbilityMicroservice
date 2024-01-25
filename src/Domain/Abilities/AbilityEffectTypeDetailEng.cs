using Domain.Enums;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Abilities;

public class AbilityEffectTypeDetailEng
{

    [BsonRepresentation(BsonType.ObjectId)]
    public Guid AbilityEffectTypeId { get; set; }
    public LanguageCode LanguageCode { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    [BsonIgnore]
    public AbilityEffectType AbilityEffectType { get; set; }

}
