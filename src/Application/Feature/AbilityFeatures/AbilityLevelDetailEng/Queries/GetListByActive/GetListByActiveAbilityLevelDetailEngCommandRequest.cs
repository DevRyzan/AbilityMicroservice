using Core.Application.Requests;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityLevelDetailEng.Queries.GetListByActive;

public class GetListByActiveAbilityLevelDetailEngCommandRequest : IRequest<List<GetListByActiveAbilityLevelDetailEngCommandResponse>>
{
    public PageRequest PageRequest { get; set; }
}
