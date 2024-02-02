using Core.Application.Requests;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityTargetTypeDetailEng.Queries.GetListByInActive;

public class GetListByInActiveAbilityTargetTypeDetailEngCommandRequest : IRequest<List<GetListByInActiveAbilityTargetTypeDetailEngCommandResponse>>
{
    public PageRequest PageRequest { get; set; }
}
