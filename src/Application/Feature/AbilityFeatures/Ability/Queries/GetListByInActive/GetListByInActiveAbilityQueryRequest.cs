using Core.Application.Requests;
using MediatR;

namespace Application.Feature.AbilityFeatures.Ability.Queries.GetListByInActive;

public class GetListByInActiveAbilityQueryRequest : IRequest<List<GetListByInActiveAbilityQueryResponse>>
{
    public PageRequest PageRequest { get; set; }
}
