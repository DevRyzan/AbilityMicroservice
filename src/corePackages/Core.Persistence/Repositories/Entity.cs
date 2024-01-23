namespace Core.Persistence.Repositories;

public class Entity<TIdType>
{
    public TIdType Id { get; set; }
    public string? Code { get; set; }
    public bool Status { get; set; }
    public bool? IsDeleted { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
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