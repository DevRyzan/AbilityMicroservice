using Core.Application.Requests;
using MediatR;


namespace Application.Feature.AbilityFeatures.AbilityEffectDisableTypes.Queries.GetListByActive;

public class GetListByActiveAbilityEffectDisableTypeRequest : IRequest<List<GetListByActiveAbilityEffectDisableTypeResponse>>
{
    public PageRequest PageRequest { get; set; }

}
