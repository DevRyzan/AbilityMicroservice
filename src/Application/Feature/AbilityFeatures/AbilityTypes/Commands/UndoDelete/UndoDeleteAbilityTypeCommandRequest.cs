using Application.Feature.AbilityFeatures.AbilityTypes.Dtos;
using MediatR;


namespace Application.Feature.AbilityFeatures.AbilityTypes.Commands.UndoDelete;

public class UndoDeleteAbilityTypeCommandRequest : IRequest<UndoDeleteAbilityTypeCommandResponse>
{
    public UndoDeleteAbilityEffectTypeDto UndoDeleteAbilityTypeDto { get; set; }
}
