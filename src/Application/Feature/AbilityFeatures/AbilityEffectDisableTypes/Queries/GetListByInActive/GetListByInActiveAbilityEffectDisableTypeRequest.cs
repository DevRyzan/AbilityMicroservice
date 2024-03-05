using Core.Application.Requests;
using MediatR;


namespace Application.Feature.AbilityFeatures.AbilityEffectDisableTypes.Queries.GetListByInActive;

public class GetListByInActiveAbilityEffectDisableTypeRequest : IRequest<List<GetListByInActiveAbilityEffectDisableTypeResponse>>
{
    public PageRequest PageRequest { get; set; }

}
