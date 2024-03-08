

namespace Application.Feature.AbilityFeatures.AbilityEffects.Commands.Create;

public class CreateAbilityEffectResponse
{
    public string Id { get; set; }
    public string? AbilityId { get; set; }

    public string Name { get; set; }
    public string Description { get; set; }
    public double Duration { get; set; }
    public double Value { get; set; }

    public string? ActivationTypeId { get; set; }

    public string? EffectTypeId { get; set; }

    public string? AbilityEffectDisabledTypeId { get; set; }
}
