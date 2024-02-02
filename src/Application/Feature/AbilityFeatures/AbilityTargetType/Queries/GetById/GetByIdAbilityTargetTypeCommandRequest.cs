using Application.Feature.AbilityFeatures.AbilityTargetType.Dto;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityTargetType.Queries.GetById;

public class GetByIdAbilityTargetTypeCommandRequest : IRequest<GetByIdAbilityTargetTypeCommandResponse>
{
    public GetByIdAbilityTargetTypeDto GetByIdAbilityTargetTypeDto { get; set; }
}
