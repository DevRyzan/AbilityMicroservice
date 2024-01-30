using Application.Feature.AbilityFeatures.AbilityLevel.Dto;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityLevel.Commands.Remove;

public class RemoveAbilityLevelCommandRequest : IRequest<RemoveAbilityLevelCommandResponse>
{
    public RemoveAbilityLevelDto RemoveAbilityLevelDto { get; set; }
}
