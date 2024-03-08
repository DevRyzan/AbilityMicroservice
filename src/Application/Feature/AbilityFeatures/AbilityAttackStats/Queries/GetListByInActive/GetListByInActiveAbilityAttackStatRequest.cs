using Core.Application.Requests;
using MediatR;


namespace Application.Feature.AbilityFeatures.AbilityAttackStats.Queries.GetListByInActive;

public class GetListByInActiveAbilityAttackStatRequest : IRequest<List<GetListByInActiveAbilityAttackStatResponse>>
{
    public PageRequest PageRequest { get; set; }

}
