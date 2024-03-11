using Core.Application.Requests;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityEffectStats.Queries.GetListByInActive;

public class GetListByInActiveAbilityEffectStatRequest : IRequest<List<GetListByInActiveAbilityEffectStatResponse>>
{
    public PageRequest PageRequest { get; set; }

}
