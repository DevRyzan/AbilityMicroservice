using Application.Feature.AbilityFeatures.AbilitySelfEffectStats.Dtos;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilitySelfEffectStats.Commands.ChangeStatus;

public class ChangeStatusAbilitySelfEffectStatRequest : IRequest<ChangeStatusAbilitySelfEffectStatResponse>
{
    public ChangeStatusAbilitySelfEffectStatDto ChangeStatusAbilitySelfEffectStatDto { get; set; }
}
