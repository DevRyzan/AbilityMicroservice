
using Application.Feature.AbilityFeatures.AbilitySelfEffectStats.Dtos;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilitySelfEffectStats.Commands.Update;

public class UpdateAbilitySelfEffectStatRequest : IRequest<UpdateAbilitySelfEffectStatResponse>
{
    public UpdateAbilitySelfEffectStatDto UpdateAbilitySelfEffectStatDto { get; set; }
}
