using Application.Feature.AbilityFeatures.Ability.Dtos;
using MediatR;

namespace Application.Feature.AbilityFeatures.Ability.Commands.Delete;

public class DeleteAbilityCommandRequest : IRequest<DeleteAbilityCommandResponse>
{
    public DeleteAbilityDto DeleteAbilityDto { get; set; }
}
