namespace Application.Feature.AbilityFeatures.ResourceCostType.Commands.ChangeStatus;

public class ChangeStatusResourceCostTypeCommandResponse
{
    public string Id { get; set; }
    public string Name { get; set; }
    public bool Status { get; set; }
    public bool IsDeleted { get; set; }
    public string Code { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime DeletedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
}
