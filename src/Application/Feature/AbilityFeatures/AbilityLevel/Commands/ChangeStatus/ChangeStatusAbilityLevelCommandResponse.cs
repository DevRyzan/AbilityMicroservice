using Domain.Enums;

namespace Application.Feature.AbilityFeatures.AbilityLevel.Commands.ChangeStatus;

public class ChangeStatusAbilityLevelCommandResponse
{
    public Guid Id { get; set; }
    public LevelNumber LevelNumber { get; set; }
    public double Duration { get; set; }
    public double Range { get; set; }
    public double EnergyCost { get; set; }
    public string IconUrl { get; set; }
    public string? Code { get; set; }
    public bool Status { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public DateTime? DeletedDate { get; set; }

}
