using Application.Feature.AbilityFeatures.AbilitySelfEffectStats.Dtos;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilitySelfEffectStats.Commands.Create;

public class CreateAbilitySelfEffectStatRequest : IRequest<CreateAbilitySelfEffectStatResponse>
{
    public CreateAbilitySelfEffectStatDto CreateAbilitySelfEffectStatDto { get; set; }
}
