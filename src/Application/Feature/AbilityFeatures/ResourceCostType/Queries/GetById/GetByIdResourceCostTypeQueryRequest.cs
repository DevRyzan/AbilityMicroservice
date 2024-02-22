using Application.Feature.AbilityFeatures.ResourceCostType.Dto;
using MediatR;

namespace Application.Feature.AbilityFeatures.ResourceCostType.Queries.GetById;

public class GetByIdResourceCostTypeQueryRequest : IRequest<GetByIdResourceCostTypeQueryResponse>
{
    public GetByIdResourcesCostTypeDto GetByIdResourcesCostTypeDto { get; set; }
}
