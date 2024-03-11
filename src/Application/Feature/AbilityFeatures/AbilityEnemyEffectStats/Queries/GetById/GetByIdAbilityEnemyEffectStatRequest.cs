
using Application.Feature.AbilityFeatures.AbilityEnemyEffectStats.Dto;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityEnemyEffectStats.Queries.GetById;

public class GetByIdAbilityEnemyEffectStatRequest : IRequest<GetByIdAbilityEnemyEffectStatResponse>
{
    public GetByIdAbilityEnemyEffectStatDto GetByIdAbilityEnemyEffectStatDto { get; set; }
}
