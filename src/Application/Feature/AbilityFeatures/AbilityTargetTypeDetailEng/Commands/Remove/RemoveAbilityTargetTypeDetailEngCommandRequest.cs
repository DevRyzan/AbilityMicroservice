using Application.Feature.AbilityFeatures.AbilityTargetTypeDetailEng.Dto;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityTargetTypeDetailEng.Commands.Remove;

public class RemoveAbilityTargetTypeDetailEngCommandRequest : IRequest<RemoveAbilityTargetTypeDetailEngCommandResponse>
{
    public RemoveAbilityTargetTypeDetailEngDto RemoveAbilityTargetTypeDetailEngDto { get; set; }
}
