using Application.Feature.AbilityFeatures.ResourceCostType.Dto;
using MediatR;

namespace Application.Feature.AbilityFeatures.ResourceCostType.Commands.Remove;

public class RemoveResourceCostTypeCommandRequest : IRequest<RemoveResourceCostTypeCommandResponse>
{
    public RemoveResourcesCostTypeDto RemoveResourcesCostTypeDto { get; set; }
}
