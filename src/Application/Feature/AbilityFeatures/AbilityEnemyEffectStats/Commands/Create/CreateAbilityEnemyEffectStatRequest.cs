using Application.Feature.AbilityFeatures.AbilityEnemyEffectStats.Dto;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityEnemyEffectStats.Commands.Create;

public class CreateAbilityEnemyEffectStatRequest : IRequest<CreateAbilityEnemyEffectStatResponse>
{
    public CreateAbilityEnemyEffectStatDto CreateAbilityEnemyEffectStatDto { get; set; }
}
