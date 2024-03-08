using Application.Feature.AbilityFeatures.AbilityEffects.Dtos;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityEffects.Commands.UndoDelete;

public class UndoDeleteAbilityEffectRequest : IRequest<UndoDeleteAbilityEffectResponse>
{
    public UndoDeleteAbilityEffectDto UndoDeleteAbilityEffectDto { get; set; }
}
