using Core.Application.Requests;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityCategory.Queries.GetListByInActive;

public class GetListByInActiveAbilityCategoryQueryRequest : IRequest<List<GetListByInActiveAbilityCategoryQueryResponse>>
{
    public PageRequest PageRequest { get; set; }
}
