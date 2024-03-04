using Application.Feature.AbilityFeatures.AbilityEffectTypes.Dtos;
using MediatR;


namespace Application.Feature.AbilityFeatures.AbilityEffectTypes.Commands.Update;

public class UpdateAbilityEffectTypeRequest : IRequest<UpdateAbilityEffectTypeResponse>
{
    public UpdateAbilityEffectTypeDto UpdateAbilityEffectTypeDto { get; set; }
}
