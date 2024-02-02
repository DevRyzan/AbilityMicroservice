using Core.Application.Requests;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityTargetType.Queries.GetListByActive;

public class GetByActiveListAbilityTargetTypeCommandRequest : IRequest<List<GetByActiveListAbilityTargetTypeCommandResponse>>
{
    public PageRequest PageRequest { get; set; }
}
