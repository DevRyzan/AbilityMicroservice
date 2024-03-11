using Application.Feature.AbilityFeatures.AbilityEffectStats.Dtos;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityEffectStats.Commands.ChangeStatus;

public class ChangeStatusAbilityEffectStatRequest : IRequest<ChangeStatusAbilityEffectStatResponse>
{
    public ChangeStatusAbilityEffectStatDto ChangeStatusAbilityEffectStatDto { get; set; }
}
