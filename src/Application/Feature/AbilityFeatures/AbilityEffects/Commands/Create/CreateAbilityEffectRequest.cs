using Application.Feature.AbilityFeatures.AbilityEffects.Dtos;
using MediatR;


namespace Application.Feature.AbilityFeatures.AbilityEffects.Commands.Create;

public class CreateAbilityEffectRequest : IRequest<CreateAbilityEffectResponse>
{
    public CreateAbilityEffectDto CreateAbilityEffectDto { get; set; }
}
