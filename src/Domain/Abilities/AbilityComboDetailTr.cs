using Core.Persistence.Repositories;
using Domain.Enums;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Abilities;

public class AbilityComboDetailTr : Entity<Guid>
{
    [BsonRepresentation(BsonType.ObjectId)]
    public Guid AbilityComboId { get; set; }
    public LanguageCode LanguageCode { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string ComboType { get; set; }

    [BsonIgnore]
    public AbilityCombo AbilityCombo { get; set; }
}
