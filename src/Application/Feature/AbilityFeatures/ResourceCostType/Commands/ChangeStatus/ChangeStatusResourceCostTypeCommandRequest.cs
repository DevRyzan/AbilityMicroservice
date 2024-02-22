using Application.Feature.AbilityFeatures.ResourceCostType.Dto;
using MediatR;

namespace Application.Feature.AbilityFeatures.ResourceCostType.Commands.ChangeStatus;

public class ChangeStatusResourceCostTypeCommandRequest : IRequest<ChangeStatusResourceCostTypeCommandResponse>
{
    public ChangeStatusResourceCostTypeDto ChangeStatusResourceCostTypeDto { get; set; }
}
