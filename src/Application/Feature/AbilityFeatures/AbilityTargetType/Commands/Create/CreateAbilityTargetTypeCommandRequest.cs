using Application.Feature.AbilityFeatures.AbilityTargetType.Dto;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityTargetType.Commands.Create;

public class CreateAbilityTargetTypeCommandRequest : IRequest<CreateAbilityTargetTypeCommandResponse>
{
    public CreateAbilityTargetTypeDto CreateAbilityTargetTypeDto { get; set; }
}
