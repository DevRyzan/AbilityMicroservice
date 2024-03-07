using Application.Feature.AbilityFeatures.AbilityAttackStats.Dto;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityAttackStats.Commands.ChangeStatus;

public class ChangeStatusAbilityAttackStatRequest : IRequest<ChangeStatusAbilityAttackStatResponse>
{
    public ChangeStatusAbilityAttackStatDto ChangeStatusAbilityAttackStatDto { get; set; }
}
