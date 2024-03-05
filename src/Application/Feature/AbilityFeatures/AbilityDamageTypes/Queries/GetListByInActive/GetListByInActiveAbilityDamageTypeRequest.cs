using Core.Application.Requests;
using MediatR;


namespace Application.Feature.AbilityFeatures.AbilityDamageTypes.Queries.GetListByInActive;

public class GetListByInActiveAbilityDamageTypeRequest : IRequest<List<GetListByInActiveAbilityDamageTypeResponse>>
{
    public PageRequest PageRequest { get; set; }

}
