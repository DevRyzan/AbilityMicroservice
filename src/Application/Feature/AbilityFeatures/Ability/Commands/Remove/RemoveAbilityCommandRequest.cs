using Application.Feature.AbilityFeatures.Ability.Dtos;
using MediatR;

namespace Application.Feature.AbilityFeatures.Ability.Commands.Remove;

public class RemoveAbilityCommandRequest : IRequest<RemoveAbilityCommandResponse>
{
    public RemoveAbilityDto RemoveAbilityDto { get; set; }
}
