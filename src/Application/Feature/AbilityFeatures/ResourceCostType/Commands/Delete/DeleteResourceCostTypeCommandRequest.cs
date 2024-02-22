using Application.Feature.AbilityFeatures.ResourceCostType.Dto;
using MediatR;

namespace Application.Feature.AbilityFeatures.ResourceCostType.Commands.Delete;

public class DeleteResourceCostTypeCommandRequest : IRequest<DeleteResourceCostTypeCommandResponse>
{
    public DeleteResourcesCostTypeDto DeleteResourcesCostTypeDto { get; set; }
}
