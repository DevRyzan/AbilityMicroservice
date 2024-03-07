using Application.Feature.AbilityFeatures.AbilityAllyEffectStats.Dto;
using MediatR;


namespace Application.Feature.AbilityFeatures.AbilityAllyEffectStats.Commands.Remove;

public class RemoveAbilityAllyEffectStatRequest : IRequest<RemoveAbilityAllyEffectStatResponse>
{
    public RemoveAbilityAllyEffectStatDto RemoveAbilityAllyEffectStatDto { get; set; }
}
