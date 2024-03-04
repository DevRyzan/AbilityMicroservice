using Core.Application.Requests;
using MediatR;


namespace Application.Feature.AbilityFeatures.AbilityEffectTypes.Queries.GetListByInActive;

public class GetByInActiveListAbilityEffectTypeRequest : IRequest<List<GetByInActiveListAbilityEffectTypeResponse>>
{
    public PageRequest PageRequest { get; set; }

}
