using Application.Feature.AbilityFeatures.AbilityAttackStats.Dto;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityAttackStats.Commands.Delete;

public class DeleteAbilityAttackStatRequest : IRequest<DeleteAbilityAttackStatResponse>
{
    public DeleteAbilityAttackStatDto DeleteAbilityAttackStatDto { get; set; }
}
