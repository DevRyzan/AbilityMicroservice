using Core.Application.Requests;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityLevel.Queries.GetListByInActive;

public class GetListByInActiveAbilityLevelCommandRequest : IRequest<List<GetListByInActiveAbilityLevelCommandResponse>>
{
    public PageRequest PageRequest { get; set; }
}
