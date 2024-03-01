using Application.Feature.AbilityFeatures.AbilityEffectTypes.Dtos;
using MediatR;


namespace Application.Feature.AbilityFeatures.AbilityEffectTypes.Commands.Create;

public class CreateAbilityEffectTypeRequest : IRequest<CreateAbilityEffectTypeResponse>
{
    public CreateAbilityEffectTypeDto CreateAbilityEffectTypeDto { get; set; }
}
