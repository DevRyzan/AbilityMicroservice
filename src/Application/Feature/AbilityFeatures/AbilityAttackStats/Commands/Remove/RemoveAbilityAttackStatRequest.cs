using Application.Feature.AbilityFeatures.AbilityAttackStats.Dto;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityAttackStats.Commands.Remove;

public class RemoveAbilityAttackStatRequest : IRequest<RemoveAbilityAttackStatResponse>
{
    public RemoveAbilityAttackStatDto RemoveAbilityAttackStatDto { get; set; }
}
