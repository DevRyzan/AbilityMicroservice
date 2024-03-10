using Application.Feature.AbilityFeatures.AbilityEffectStats.Dtos;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityEffectStats.Commands.UndoDelete;

public class UndoDeleteAbilityEffectStatRequest : IRequest<UndoDeleteAbilityEffectStatResponse>
{
    public UndoDeleteAbilityEffectStatDto UndoDeleteAbilityEffectStatDto { get; set; }
}
