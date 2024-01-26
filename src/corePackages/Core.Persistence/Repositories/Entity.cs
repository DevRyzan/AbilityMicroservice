using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Core.Persistence.Repositories;

public class Entity<TIdType>
{
    [BsonId]
    [BsonRepresentation(BsonType.String)]
    public TIdType Id { get; set; }
    public string? Code { get; set; }
    public bool Status { get; set; }
    public bool IsDeleted { get; set; }

    [BsonRepresentation(BsonType.DateTime)]
    public DateTime CreatedDate { get; set; }
    [BsonRepresentation(BsonType.DateTime)]
    public DateTime? UpdatedDate { get; set; }
    [BsonRepresentation(BsonType.DateTime)]
    public DateTime? DeletedDate { get; set; }
    public Entity()
    {
    }

    public Entity(TIdType id, string code)
    {
        Id = id;
        Code = code;
    }

    public Entity(TIdType id)
    {
        Id = id;
    }
}