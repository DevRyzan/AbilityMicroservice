using Application.Feature.AbilityFeatures.AbilityEnemyEffectStats.Dto;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityEnemyEffectStats.Commands.Delete;

public class DeleteAbilityEnemyEffectStatRequest : IRequest<DeleteAbilityEnemyEffectStatResponse>
{
    public DeleteAbilityEnemyEffectStatDto DeleteAbilityEnemyEffectStatDto { get; set; }
}
