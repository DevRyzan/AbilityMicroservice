using Application.Feature.AbilityFeatures.AbilitySelfEffectStats.Dtos;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilitySelfEffectStats.Commands.Remove;

public class RemoveAbilitySelfEffectStatRequest : IRequest<RemoveAbilitySelfEffectStatResponse>
{
    public RemoveAbilitySelfEffectStatDto RemoveAbilitySelfEffectStatDto { get; set; }
}
