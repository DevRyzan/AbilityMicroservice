using Core.Application.Requests;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityLevel.Queries.GetListByActive;

public class GetListByActiveAbilityLevelCommandRequest : IRequest<List<GetListByActiveAbilityLevelCommandResponse>>
{
    public PageRequest PageRequest { get; set; }
}
