using Core.Application.Requests;
using MediatR;


namespace Application.Feature.AbilityFeatures.AbilityDamageTypes.Queries.GetListByActive;

public class GetListByActiveAbilityDamageTypeRequest : IRequest<List<GetListByActiveAbilityDamageTypeResponse>>
{
    public PageRequest PageRequest { get; set; }

}
