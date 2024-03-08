using Application.Feature.AbilityFeatures.AbilityEffects.Dtos;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityEffects.Commands.Delete;

public class DeleteAbilityEffectRequest : IRequest<DeleteAbilityEffectResponse>
{
    public DeleteAbilityEffectDto DeleteAbilityEffectDto { get; set; }
}
