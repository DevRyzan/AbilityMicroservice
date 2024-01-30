using Application.Feature.AbilityFeatures.AbilityLevel.Dto;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityLevel.Commands.Create;

public class CreateAbilityLevelCommandRequest : IRequest<CreateAbilityLevelCommandResponse>
{
    public CreateAbilityLevelDto CreateAbilityLevelDto { get; set; }
}
