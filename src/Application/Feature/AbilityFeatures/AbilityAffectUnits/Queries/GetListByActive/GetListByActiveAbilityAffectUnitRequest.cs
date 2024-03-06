using Core.Application.Requests;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityAffectUnits.Queries.GetListByActive;

public class GetListByActiveAbilityAffectUnitRequest : IRequest<List<GetListByActiveAbilityAffectUnitResponse>>
{
    public PageRequest PageRequest { get; set; }

}
