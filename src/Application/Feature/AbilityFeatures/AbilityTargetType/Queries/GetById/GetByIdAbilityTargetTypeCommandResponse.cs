namespace Application.Feature.AbilityFeatures.AbilityTargetType.Queries.GetById;

public class GetByIdAbilityTargetTypeCommandResponse
{
    public Guid Id { get; set; }
    public Guid AbilityId { get; set; }
    public bool IsSingleTarget { get; set; }
    public bool IsAreaTarget { get; set; }
    public double Radius { get; set; }
    public string IconUrl { get; set; }

    public bool IsDeleted { get; set; }
    public bool Status { get; set; }

    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
    public DateTime DeletedDate { get; set; }
}
