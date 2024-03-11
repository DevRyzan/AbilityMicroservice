using Application.Feature.AbilityFeatures.AbilityEffectStats.Dtos;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityEffectStats.Commands.Remove;

public class RemoveAbilityEffectStatRequest : IRequest<RemoveAbilityEffectStatResponse>
{
    public RemoveAbilityEffectStatDto RemoveAbilityEffectStatDto { get; set; }
}
