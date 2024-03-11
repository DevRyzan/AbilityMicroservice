using Application.Feature.AbilityFeatures.AbilityEnemyEffectStats.Dto;
using MediatR;


namespace Application.Feature.AbilityFeatures.AbilityEnemyEffectStats.Commands.Update;

public class UpdateAbilityEnemyEffectStatRequest : IRequest<UpdateAbilityEnemyEffectStatResponse>
{
    public UpdateAbilityEnemyEffectStatDto UpdateAbilityEnemyEffectStatDto { get; set; }
}
