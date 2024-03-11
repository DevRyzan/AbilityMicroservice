using Application.Feature.AbilityFeatures.AbilitySelfEffectStats.Dtos;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilitySelfEffectStats.Commands.Delete;

public class DeleteAbilitySelfEffectStatRequest : IRequest<DeleteAbilitySelfEffectStatResponse>
{
    public DeleteAbilitySelfEffectStatDto DeleteAbilitySelfEffectStatDto { get; set; }
}
