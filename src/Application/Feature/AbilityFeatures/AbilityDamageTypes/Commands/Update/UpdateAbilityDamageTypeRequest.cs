
using Application.Feature.AbilityFeatures.AbilityDamageTypes.Dtos;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityDamageTypes.Commands.Update;

public class UpdateAbilityDamageTypeRequest : IRequest<UpdateAbilityDamageTypeResponse>
{
    public UpdateAbilityDamageTypeDto UpdateAbilityDamageTypeDto { get; set; }
}
