using Application.Feature.AbilityFeatures.AbilityEnemyEffectStats.Dto;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityEnemyEffectStats.Commands.Remove;

public class RemoveAbilityEnemyEffectStatRequest : IRequest<RemoveAbilityEnemyEffectStatResponse>
{
    public RemoveAbilityEnemyEffectStatDto RemoveAbilityEnemyEffectStatDto { get; set; }
}
