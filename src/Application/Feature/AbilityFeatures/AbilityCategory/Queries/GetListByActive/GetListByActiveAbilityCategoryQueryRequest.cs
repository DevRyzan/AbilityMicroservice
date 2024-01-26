using Core.Application.Requests;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityCategory.Queries.GetListByActive;

public class GetListByActiveAbilityCategoryQueryRequest : IRequest<List<GetListByActiveAbilityCategoryQueryResponse>>
{
    public PageRequest PageRequest { get; set; }

}
