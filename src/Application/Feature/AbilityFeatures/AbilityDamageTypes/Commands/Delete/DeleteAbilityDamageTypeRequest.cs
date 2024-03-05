using Application.Feature.AbilityFeatures.AbilityDamageTypes.Dtos;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityDamageTypes.Commands.Delete;

public class DeleteAbilityDamageTypeRequest : IRequest<DeleteAbilityDamageTypeResponse>
{
    public DeleteAbilityDamageTypeDto DeleteAbilityDamageTypeDto { get; set; }
}
