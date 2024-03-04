using Core.Application.Requests;
using MediatR;


namespace Application.Feature.AbilityFeatures.AbilityEffectTypes.Queries.GetListByActive;

public class GetByActiveListAbilityEffectTypeRequest : IRequest<List<GetByActiveListAbilityEffectTypeResponse>>
{
    public PageRequest PageRequest { get; set; }

}
