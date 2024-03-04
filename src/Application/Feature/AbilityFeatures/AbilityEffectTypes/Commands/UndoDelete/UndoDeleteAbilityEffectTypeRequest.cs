using Application.Feature.AbilityFeatures.AbilityEffectTypes.Dtos;
using MediatR;


namespace Application.Feature.AbilityFeatures.AbilityEffectTypes.Commands.UndoDelete;

public class UndoDeleteAbilityEffectTypeRequest : IRequest<UndoDeleteAbilityEffectTypeResponse>
{
    public UndoDeleteAbilityEffectTypeDto UndoDeleteAbilityEffectTypeDto { get; set; }
}
