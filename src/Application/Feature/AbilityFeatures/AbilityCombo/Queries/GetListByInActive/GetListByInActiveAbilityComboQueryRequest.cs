using Core.Application.Requests;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityCombo.Queries.GetListByInActive;

public class GetListByInActiveAbilityComboQueryRequest : IRequest<List<GetListByInActiveAbilityComboQueryResponse>>
{
    public PageRequest PageRequest { get; set; }
}
