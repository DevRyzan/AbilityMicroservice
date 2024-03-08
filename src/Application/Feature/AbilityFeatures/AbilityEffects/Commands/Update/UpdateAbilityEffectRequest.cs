using Application.Feature.AbilityFeatures.AbilityEffects.Dtos;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityEffects.Commands.Update;

public class UpdateAbilityEffectRequest : IRequest<UpdateAbilityEffectResponse>
{
    public UpdateAbilityEffectDto UpdateAbilityEffectDto { get; set; }
}
