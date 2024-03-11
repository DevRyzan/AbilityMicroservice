using Core.Application.Requests;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityEnemyEffectStats.Queries.GetListByActive;

public class GetListByActiveAbilityEnemyEffectStatRequest : IRequest<List<GetListByActiveAbilityEnemyEffectStatResponse>>
{
    public PageRequest PageRequest { get; set; }

}
