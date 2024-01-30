using Application.Feature.AbilityFeatures.AbilityLevel.Dto;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityLevel.Commands.Delete;

public class DeleteAbilityLevelCommandRequest : IRequest<DeleteAbilityLevelCommandResponse>
{
    public DeleteAbilityLevelDto DeleteAbilityLevelDto { get; set; }
}
