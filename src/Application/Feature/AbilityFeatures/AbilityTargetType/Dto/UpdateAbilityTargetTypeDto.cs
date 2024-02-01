namespace Application.Feature.AbilityFeatures.AbilityTargetType.Dto;

public class UpdateAbilityTargetTypeDto
{
    public Guid Id { get; set; }
    public Guid AbilityId { get; set; }
    public bool IsSingleTarget { get; set; }
    public bool IsAreaTarget { get; set; }
    public double Radius { get; set; }
    public string IconUrl { get; set; }
}

