using Application.Feature.AbilityFeatures.AbilityTargetType.Dto;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityTargetType.Commands.Delete;

public class DeleteAbilityTargetTypeCommandRequest : IRequest<DeleteAbilityTargetTypeCommandResponse>
{
    public DeleteAbilityTargetTypeDto DeleteAbilityTargetTypeDto { get; set; }
}
