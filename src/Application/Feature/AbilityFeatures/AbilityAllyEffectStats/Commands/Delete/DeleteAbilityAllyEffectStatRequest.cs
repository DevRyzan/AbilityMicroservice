using Application.Feature.AbilityFeatures.AbilityAllyEffectStats.Dto;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityAllyEffectStats.Commands.Delete;

public class DeleteAbilityAllyEffectStatRequest : IRequest<DeleteAbilityAllyEffectStatResponse>
{
    public DeleteAbilityAllyEffectStatDto DeleteAbilityAllyEffectStatDto { get; set; }
}
