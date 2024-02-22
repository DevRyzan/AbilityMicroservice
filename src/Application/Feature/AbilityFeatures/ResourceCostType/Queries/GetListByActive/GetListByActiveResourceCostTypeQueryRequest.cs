using Core.Application.Requests;
using MediatR;

namespace Application.Feature.AbilityFeatures.ResourceCostType.Queries.GetListByActive;

public class GetListByActiveResourceCostTypeQueryRequest : IRequest<List<GetListByActiveResourceCostTypeQueryResponse>>
{
    public PageRequest PageRequest { get; set; }
}
