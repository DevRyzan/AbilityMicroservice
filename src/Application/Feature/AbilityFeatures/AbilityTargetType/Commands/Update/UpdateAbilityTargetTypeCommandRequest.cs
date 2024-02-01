using Application.Feature.AbilityFeatures.AbilityTargetType.Dto;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityTargetType.Commands.Update;

public class UpdateAbilityTargetTypeCommandRequest : IRequest<UpdateAbilityTargetTypeCommandResponse>
{
    public UpdateAbilityTargetTypeDto UpdateAbilityTargetTypeDto { get; set; }
}
