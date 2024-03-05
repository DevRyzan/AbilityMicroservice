
using Application.Feature.AbilityFeatures.AbilityEffectDisableTypes.Dtos;
using MediatR;


namespace Application.Feature.AbilityFeatures.AbilityEffectDisableTypes.Commands.UndoDelete;

public class UndoDeleteAbilityEffectDisableTypeRequest : IRequest<UndoDeleteAbilityEffectDisableTypeResponse>
{
    public UndoDeleteAbilityEffectDisableTypeDto UndoDeleteAbilityEffectDisableTypeDto { get; set; }
}
