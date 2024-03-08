using Core.Application.Requests;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityEffects.Queries.GetListByActive;

public class GetListByActiveAbilityEffectRequest : IRequest<List<GetListByActiveAbilityEffectResponse>>
{
    public PageRequest PageRequest { get; set; }

}
