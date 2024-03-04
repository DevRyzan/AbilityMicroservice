using Application.Feature.AbilityFeatures.AbilityTypes.Dtos;
using MediatR;


namespace Application.Feature.AbilityFeatures.AbilityTypes.Commands.Remove;

public class RemoveAbilityTypeCommandRequest : IRequest<RemoveAbilityTypeCommandResponse>
{
    public RemoveAbilityTypeDto RemoveAbilityTypeDto { get; set; }
}
