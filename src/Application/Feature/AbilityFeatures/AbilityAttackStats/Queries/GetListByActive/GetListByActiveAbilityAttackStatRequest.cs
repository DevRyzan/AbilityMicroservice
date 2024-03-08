using Core.Application.Requests;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityAttackStats.Queries.GetListByActive;

public class GetListByActiveAbilityAttackStatRequest : IRequest<List<GetListByActiveAbilityAttackStatResponse>>
{
    public PageRequest PageRequest { get; set; }

}
