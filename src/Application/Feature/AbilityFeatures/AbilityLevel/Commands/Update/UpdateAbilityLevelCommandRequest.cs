using Application.Feature.AbilityFeatures.AbilityLevel.Dto;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityLevel.Commands.Update;

public class UpdateAbilityLevelCommandRequest : IRequest<UpdateAbilityLevelCommandResponse>
{
    public UpdateAbilityLevelDto UpdateAbilityLevelDto { get; set; }
}
