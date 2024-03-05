using Application.Feature.AbilityFeatures.AbilityDamageTypes.Dtos;
using MediatR;


namespace Application.Feature.AbilityFeatures.AbilityDamageTypes.Commands.Remove;

public class RemoveAbilityDamageTypeRequest : IRequest<RemoveAbilityDamageTypeResponse>
{
    public RemoveAbilityDamageTypeDto RemoveAbilityDamageTypeDto { get; set; }
}
