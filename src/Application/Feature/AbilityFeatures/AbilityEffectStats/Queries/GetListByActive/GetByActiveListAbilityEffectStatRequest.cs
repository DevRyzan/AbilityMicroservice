using Core.Application.Requests;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityEffectStats.Queries.GetListByActive;

public class GetByActiveListAbilityEffectStatRequest : IRequest<List<GetByActiveListAbilityEffectStatResponse>>
{
    public PageRequest PageRequest { get; set; }

}
