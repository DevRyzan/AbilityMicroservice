using Core.Persistence.Repositories;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;


namespace Domain.Abilities;

public class AbilityEffect : Entity<string>
{
    [BsonRepresentation(BsonType.ObjectId)]
    public string AbilityId { get; set; }

    public string Name { get; set; }
    public string Description { get; set; }
    public double Duration { get; set; }
    public double Value { get; set; }

    [BsonRepresentation(BsonType.ObjectId)]
    public string ActivationTypeId { get; set; }

    [BsonRepresentation(BsonType.ObjectId)]
    public string EffectTypeId { get; set; }

    [BsonRepresentation(BsonType.ObjectId)]
    public string? AbilityEffectDisabledTypeId { get; set; }
}
