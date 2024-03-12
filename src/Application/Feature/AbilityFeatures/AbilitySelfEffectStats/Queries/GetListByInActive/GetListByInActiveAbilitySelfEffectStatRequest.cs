using Core.Application.Requests;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilitySelfEffectStats.Queries.GetListByInActive;

public class GetListByInActiveAbilitySelfEffectStatRequest : IRequest<List<GetListByInActiveAbilitySelfEffectStatResponse>>
{
    public PageRequest PageRequest { get; set; }

}
