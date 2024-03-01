
using Core.Application.Requests;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityTypes.Queries.GetListByActive;

public class GetListByActiveAbilityTypeQueryRequest : IRequest<List<GetListByActiveAbilityTypeQueryResponse>>
{
    public PageRequest PageRequest { get; set; }
}
