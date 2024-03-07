using Core.Application.Requests;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityAllyEffectStats.Queries.GetListByActive;

public class GetListByActiveAbilityAllyEffectStatRequest : IRequest<List<GetListByActiveAbilityAllyEffectStatResponse>>
{
    public PageRequest PageRequest { get; set; }

}
