using Application.Feature.AbilityFeatures.AbilityEffectStats.Dtos;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityEffectStats.Commands.Create;

public class CreateAbilityEffectStatRequest : IRequest<CreateAbilityEffectStatResponse>
{
    public CreateAbilityEffectStatDto CreateAbilityEffectStatDto { get; set; }
}
