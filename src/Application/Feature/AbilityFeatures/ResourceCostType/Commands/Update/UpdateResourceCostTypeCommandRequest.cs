using Application.Feature.AbilityFeatures.ResourceCostType.Dto;
using MediatR;

namespace Application.Feature.AbilityFeatures.ResourceCostType.Commands.Update;

public class UpdateResourceCostTypeCommandRequest : IRequest<UpdateResourceCostTypeCommandResponse>
{
    public UpdateResourcesCostTypeDto UpdateResourcesCostTypeDto { get; set; }
}
