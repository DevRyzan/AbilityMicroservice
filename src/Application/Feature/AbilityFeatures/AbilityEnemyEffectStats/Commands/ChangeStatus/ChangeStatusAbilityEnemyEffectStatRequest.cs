using Application.Feature.AbilityFeatures.AbilityEnemyEffectStats.Dto;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityEnemyEffectStats.Commands.ChangeStatus;

public class ChangeStatusAbilityEnemyEffectStatRequest : IRequest<ChangeStatusAbilityEnemyEffectStatResponse>
{
    public ChangeStatusAbilityEnemyEffectStatDto ChangeStatusAbilityEnemyEffectStatDto { get; set; }
}
