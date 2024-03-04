
using Application.Feature.AbilityFeatures.AbilityEffectTypes.Dtos;
using MediatR;


namespace Application.Feature.AbilityFeatures.AbilityEffectTypes.Commands.Remove;

public class RemoveAbilityEffectTypeRequest : IRequest<RemoveAbilityEffectTypeResponse>
{
    public RemoveAbilityEffectTypeDto RemoveAbilityEffectTypeDto { get; set; }
}
