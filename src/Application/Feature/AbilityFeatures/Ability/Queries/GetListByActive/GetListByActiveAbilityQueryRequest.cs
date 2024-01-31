using Core.Application.Requests;
using MediatR;

namespace Application.Feature.AbilityFeatures.Ability.Queries.GetListByActive;

public class GetListByActiveAbilityQueryRequest : IRequest<List<GetListByActiveAbilityQueryResponse>>
{
    public PageRequest PageRequest { get; set; }
}
