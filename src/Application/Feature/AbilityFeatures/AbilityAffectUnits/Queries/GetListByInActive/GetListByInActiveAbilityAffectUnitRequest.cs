using Core.Application.Requests;
using MediatR;


namespace Application.Feature.AbilityFeatures.AbilityAffectUnits.Queries.GetListByInActive;

public class GetListByInActiveAbilityAffectUnitRequest : IRequest<List<GetListByInActiveAbilityAffectUnitResponse>>
{
    public PageRequest PageRequest { get; set; }

}
