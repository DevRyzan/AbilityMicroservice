using Application.Feature.AbilityFeatures.AbilityAllyEffectStats.Dto;
using MediatR;


namespace Application.Feature.AbilityFeatures.AbilityAllyEffectStats.Commands.Update;

public class UpdateAbilityAllyEffectStatRequest : IRequest<UpdateAbilityAllyEffectStatResponse>
{
    public UpdateAbilityAllyEffectStatDto UpdateAbilityAllyEffectStatDto { get; set; }
}
