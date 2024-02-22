using Application.Feature.AbilityFeatures.ResourceCostType.Dto;
using MediatR;

namespace Application.Feature.AbilityFeatures.ResourceCostType.Commands.UndoDelete;

public class UndoDeleteResourceCostTypeCommandRequest : IRequest<UndoDeleteResourceCostTypeCommandResponse>
{
    public UndoDeleteResourcesCostTypeDto UndoDeleteResourcesCostTypeDto { get; set; }
}
