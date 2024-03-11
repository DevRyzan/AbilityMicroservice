
using Application.Feature.AbilityFeatures.AbilitySelfEffectStats.Dtos;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilitySelfEffectStats.Commands.UndoDelete;

public class UndoDeleteAbilitySelfEffectStatRequest : IRequest<UndoDeleteAbilitySelfEffectStatResponse>
{
    public UndoDeleteAbilitySelfEffectStatDto UndoDeleteAbilitySelfEffectStatDto { get; set; }
}
