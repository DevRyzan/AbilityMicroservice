using Application.Feature.AbilityFeatures.AbilityEffects.Dtos;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityEffects.Commands.Remove;

public class RemoveAbilityEffectRequest : IRequest<RemoveAbilityEffectResponse>
{
    public RemoveAbilityEffectDto RemoveAbilityEffectDto { get; set; }
}
