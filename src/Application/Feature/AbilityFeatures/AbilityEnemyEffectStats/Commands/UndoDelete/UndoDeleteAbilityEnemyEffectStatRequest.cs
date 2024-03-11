
using Application.Feature.AbilityFeatures.AbilityEnemyEffectStats.Dto;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityEnemyEffectStats.Commands.UndoDelete;

public class UndoDeleteAbilityEnemyEffectStatRequest : IRequest<UndoDeleteAbilityEnemyEffectStatResponse>
{
    public UndoDeleteAbilityEnemyEffectStatDto UndoDeleteAbilityEnemyEffectStatDto { get; set; }
}
