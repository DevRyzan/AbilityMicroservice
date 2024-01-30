using Domain.Enums;

namespace Application.Feature.AbilityFeatures.AbilityLevel.Dto;

public class UpdateAbilityLevelDto
{
    public Guid Id { get; set; }
    public LevelNumber LevelNumber { get; set; }
    public double Duration { get; set; }
    public double Range { get; set; }
    public double EnergyCost { get; set; }
    public string IconUrl { get; set; }
}
