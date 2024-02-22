using Application.Feature.AbilityFeatures.ResourceCostType.Dto;
using MediatR;

namespace Application.Feature.AbilityFeatures.ResourceCostType.Commands.Create;

public class CreateResourceCostTypeCommandRequest : IRequest<CreateResourceCostTypeCommandResponse>
{
    public CreateResourcesCostTypeDto CreateResourcesCostTypeDto { get; set; }
}
