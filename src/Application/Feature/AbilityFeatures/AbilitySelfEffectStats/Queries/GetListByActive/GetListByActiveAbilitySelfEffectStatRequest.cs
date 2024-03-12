using Core.Application.Requests;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilitySelfEffectStats.Queries.GetListByActive;

public class GetListByActiveAbilitySelfEffectStatRequest : IRequest<List<GetListByActiveAbilitySelfEffectStatResponse>>
{
    public PageRequest PageRequest { get; set; }

}
