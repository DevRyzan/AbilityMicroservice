
using Application.Feature.AbilityFeatures.AbilityDamageTypes.Dtos;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityDamageTypes.Commands.Create;

public class CreateAbilityDamageTypeRequest : IRequest<CreateAbilityDamageTypeResponse>
{
    public CreateAbilityDamageTypeDto CreateAbilityDamageTypeDto { get; set; }
}
