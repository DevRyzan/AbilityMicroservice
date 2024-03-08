using Application.Feature.AbilityFeatures.AbilityAttackStats.Dto;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityAttackStats.Commands.Create;

public class CreateAbilityAttackStatRequest : IRequest<CreateAbilityAttackStatResponse>
{
    public CreateAbilityAttackStatDto CreateAbilityAttackStatDto { get; set; }
}
