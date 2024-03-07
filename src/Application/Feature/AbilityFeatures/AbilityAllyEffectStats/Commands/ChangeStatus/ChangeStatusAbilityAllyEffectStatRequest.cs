using Application.Feature.AbilityFeatures.AbilityAllyEffectStats.Dto;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityAllyEffectStats.Commands.ChangeStatus;

public class ChangeStatusAbilityAllyEffectStatRequest : IRequest<ChangeStatusAbilityAllyEffectStatResponse>
{
    public ChangeStatusAbilityAllyEffectStatDto ChangeStatusAbilityAllyEffectStatDto { get; set; }
}
