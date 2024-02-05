using Core.Application.Requests;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityTargetTypeDetailEng.Queries.GetListByActive;

public class GetListByActiveAbilityTargetTypeDetailEngCommandRequest : IRequest<List<GetListByActiveAbilityTargetTypeDetailEngCommandResponse>>
{
    public PageRequest PageRequest { get; set; }
}
