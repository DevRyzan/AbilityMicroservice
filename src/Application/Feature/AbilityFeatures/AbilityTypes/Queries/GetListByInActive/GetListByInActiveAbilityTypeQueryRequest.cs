using Core.Application.Requests;
using MediatR;


namespace Application.Feature.AbilityFeatures.AbilityTypes.Queries.GetListByInActive;

public class GetListByInActiveAbilityTypeQueryRequest : IRequest<List<GetListByInActiveAbilityTypeQueryResponse>>
{
    public PageRequest PageRequest { get; set; }

}
