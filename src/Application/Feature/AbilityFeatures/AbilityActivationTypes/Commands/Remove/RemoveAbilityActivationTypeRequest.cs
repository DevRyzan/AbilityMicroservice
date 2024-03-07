using Application.Feature.AbilityFeatures.AbilityActivationTypes.Dto;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityActivationTypes.Commands.Remove;

public class RemoveAbilityActivationTypeRequest : IRequest<RemoveAbilityActivationTypeResponse>
{
    public RemoveAbilityActivationTypeDto RemoveAbilityActivationTypeDto { get; set; }
}
