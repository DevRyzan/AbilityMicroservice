using Core.Application.Requests;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityLevelDetailEng.Queries.GetListByInActive;

public class GetListByInActiveAbilityLevelDetailEngCommandRequest : IRequest<List<GetListByInActiveAbilityLevelDetailEngCommandResponse>>
{
    public PageRequest PageRequest { get; set; }
}
