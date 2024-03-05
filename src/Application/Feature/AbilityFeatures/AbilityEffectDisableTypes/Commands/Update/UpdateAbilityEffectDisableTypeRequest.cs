
using Application.Feature.AbilityFeatures.AbilityEffectDisableTypes.Dtos;
using MediatR;


namespace Application.Feature.AbilityFeatures.AbilityEffectDisableTypes.Commands.Update;

public class UpdateAbilityEffectDisableTypeRequest : IRequest<UpdateAbilityEffectDisableTypeResponse>
{
    public UpdateAbilityEffectDisableTypeDto UpdateAbilityEffectDisableTypeDto { get; set; }
}
