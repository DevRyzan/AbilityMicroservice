using Application.Feature.AbilityFeatures.AbilityAttackStats.Dto;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityAttackStats.Commands.UndoDelete;

public class UndoDeleteAbilityAttackStatRequest : IRequest<UndoDeleteAbilityAttackStatResponse>
{
    public UndoDeleteAbilityAttackStatDto UndoDeleteAbilityAttackStatDto { get; set; }
}
