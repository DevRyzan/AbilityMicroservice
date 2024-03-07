
using Core.Application.Requests;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityAllyEffectStats.Queries.GetListByInActive;

public class GetListByInActiveAbilityAllyEffectStatRequest : IRequest<List<GetListByInActiveAbilityAllyEffectStatResponse>>
{
    public PageRequest PageRequest { get; set; }

}
