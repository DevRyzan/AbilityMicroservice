using Application.Feature.AbilityFeatures.AbilityTargetType.Dto;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityTargetType.Commands.ChangeStatus;

public class ChangeStatusAbilityTargetTypeCommandRequest : IRequest<ChangeStatusAbilityTargetTypeCommandResponse>
{
    public ChangeStatusAbilityTargetTypeDto ChangeStatusAbilityTargetTypeDto { get; set; }
}
