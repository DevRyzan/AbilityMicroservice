using Core.Persistence.Repositories;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Abilities;

public class AbilityStat : Entity<Guid>
{
    [BsonRepresentation(BsonType.ObjectId)]
    public Guid  AbilityId { get; set; }
    public double Cooldown { get; set; }
    public double Percent { get; set; }
    public double Range { get; set; }
    public double Radius { get; set; }
    public double  EnergyCost { get; set; }

    [BsonIgnore]
    public Ability Ability { get; set; }
}
