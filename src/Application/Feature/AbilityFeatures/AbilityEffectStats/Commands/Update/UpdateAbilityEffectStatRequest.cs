using Application.Feature.AbilityFeatures.AbilityEffectStats.Dtos;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityEffectStats.Commands.Update;

public class UpdateAbilityEffectStatRequest : IRequest<UpdateAbilityEffectStatResponse>
{
    public UpdateAbilityEffectStatDto UpdateAbilityEffectStatDto { get; set; }
}
