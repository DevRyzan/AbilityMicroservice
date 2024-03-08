using Core.Application.Requests;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityEffects.Queries.GetListByInActive;

public class GetListByInActiveAbilityEffectRequest : IRequest<List<GetListByInActiveAbilityEffectResponse>>
{
    public PageRequest PageRequest { get; set; }

}
