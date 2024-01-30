using Application.Feature.AbilityFeatures.AbilityLevel.Dto;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityLevel.Commands.ChangeStatus;

public class ChangeStatusAbilityLevelCommandRequest : IRequest<ChangeStatusAbilityLevelCommandResponse>
{
    public ChangeStatusAbilityLevelDto ChangeStatusAbilityLevelDto { get; set; }
}
