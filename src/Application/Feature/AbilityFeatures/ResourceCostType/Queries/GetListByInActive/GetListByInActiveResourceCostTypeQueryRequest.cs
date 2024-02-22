using Core.Application.Requests;
using MediatR;

namespace Application.Feature.AbilityFeatures.ResourceCostType.Queries.GetListByInActive;

public class GetListByInActiveResourceCostTypeQueryRequest : IRequest<List<GetListByInActiveResourceCostTypeQueryResponse>>
{
    public PageRequest PageRequest { get; set; }
}
