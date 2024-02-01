using Core.Application.Requests;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityTargetType.Queries.GetListByInActive;

public class GetByInActiveListAbilityTargetTypeCommandRequest : IRequest<List<GetByInActiveListAbilityTargetTypeCommandResponse>>
{
    public PageRequest PageRequest { get; set; }
}
