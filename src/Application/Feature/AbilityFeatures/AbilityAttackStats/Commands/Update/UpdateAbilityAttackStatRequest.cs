
using Application.Feature.AbilityFeatures.AbilityAttackStats.Dto;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityAttackStats.Commands.Update;

public class UpdateAbilityAttackStatRequest : IRequest<UpdateAbilityAttackStatResponse>
{
    public UpdateAbilityAttackStatDto UpdateAbilityAttackStatDto { get; set; }
}
