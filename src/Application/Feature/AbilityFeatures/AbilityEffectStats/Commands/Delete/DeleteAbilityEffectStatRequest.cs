using Application.Feature.AbilityFeatures.AbilityEffectStats.Dtos;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityEffectStats.Commands.Delete;

public class DeleteAbilityEffectStatRequest : IRequest<DeleteAbilityEffectStatResponse>
{
    public DeleteAbilityEffectStatDto DeleteAbilityEffectStatDto { get; set; }
}
