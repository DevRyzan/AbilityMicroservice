using Application.Feature.AbilityFeatures.AbilityTargetType.Dto;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityTargetType.Commands.Remove;

public class RemoveAbilityTargetTypeCommandRequest : IRequest<RemoveAbilityTargetTypeCommandResponse>
{
    public RemoveAbilityTargetTypeDto RemoveAbilityTargetTypeDto { get; set; }
}
