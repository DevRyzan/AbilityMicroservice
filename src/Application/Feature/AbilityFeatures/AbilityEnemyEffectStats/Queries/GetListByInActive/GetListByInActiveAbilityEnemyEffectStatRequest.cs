using Core.Application.Requests;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityEnemyEffectStats.Queries.GetListByInActive;

public class GetListByInActiveAbilityEnemyEffectStatRequest : IRequest<List<GetListByInActiveAbilityEnemyEffectStatResponse>>
{
    public PageRequest PageRequest { get; set; }

}
