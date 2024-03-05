using Application.Feature.AbilityFeatures.AbilityEffectDisableTypes.Dtos;
using MediatR;


namespace Application.Feature.AbilityFeatures.AbilityEffectDisableTypes.Commands.Create;

public class CreateAbilityEffectDisableTypeRequest : IRequest<CreateAbilityEffectDisableTypeResponse>
{
    public CreateAbilityEffectDisableTypeDto CreateAbilityEffectDisableTypeDto { get; set; }
}
