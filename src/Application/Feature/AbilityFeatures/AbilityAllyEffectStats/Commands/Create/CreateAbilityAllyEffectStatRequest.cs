using Application.Feature.AbilityFeatures.AbilityAllyEffectStats.Dto;
using MediatR;


namespace Application.Feature.AbilityFeatures.AbilityAllyEffectStats.Commands.Create;

public class CreateAbilityAllyEffectStatRequest : IRequest<CreateAbilityAllyEffectStatResponse>
{
    public CreateAbilityAllyEffectStatDto CreateAbilityAllyEffectStatDto { get; set; }
}
