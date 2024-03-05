
using Application.Feature.AbilityFeatures.AbilityDamageTypes.Dtos;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityDamageTypes.Commands.UndoDelete;

public class UndoDeleteAbilityDamageTypeRequest : IRequest<UndoDeleteAbilityDamageTypeResponse>
{
    public UndoDeleteAbilityDamageTypeDto UndoDeleteAbilityDamageTypeDto { get; set; }
}
