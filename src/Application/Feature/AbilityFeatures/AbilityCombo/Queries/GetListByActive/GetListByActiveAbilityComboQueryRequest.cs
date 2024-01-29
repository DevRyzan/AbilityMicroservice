using Core.Application.Requests;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityCombo.Queries.GetListByActive;

public class GetListByActiveAbilityComboQueryRequest : IRequest<List<GetListByActiveAbilityComboQueryResponse>>
{
    public PageRequest PageRequest { get; set; }
}
