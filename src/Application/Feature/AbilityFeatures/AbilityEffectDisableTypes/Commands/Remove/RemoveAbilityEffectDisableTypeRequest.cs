using Application.Feature.AbilityFeatures.AbilityEffectDisableTypes.Dtos;
using MediatR;


namespace Application.Feature.AbilityFeatures.AbilityEffectDisableTypes.Commands.Remove;

public class RemoveAbilityEffectDisableTypeRequest : IRequest<RemoveAbilityEffectDisableTypeResponse>
{
    public RemoveAbilityEffectDisableTypeDto RemoveAbilityEffectDisableTypeDto { get; set; }
}
