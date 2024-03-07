using Application.Feature.AbilityFeatures.AbilityAllyEffectStats.Dto;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityAllyEffectStats.Commands.UndoDelete;

public class UndoDeleteAbilityAllyEffectStatRequest : IRequest<UndoDeleteAbilityAllyEffectStatResponse>
{
    public UndoDeleteAbilityAllyEffectStatDto UndoDeleteAbilityAllyEffectStatDto { get; set; }
}
