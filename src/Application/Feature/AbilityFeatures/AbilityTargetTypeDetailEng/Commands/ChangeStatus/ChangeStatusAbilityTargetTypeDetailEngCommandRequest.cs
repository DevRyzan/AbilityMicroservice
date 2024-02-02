using Application.Feature.AbilityFeatures.AbilityTargetTypeDetailEng.Dto;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityTargetTypeDetailEng.Commands.ChangeStatus;

public class ChangeStatusAbilityTargetTypeDetailEngCommandRequest : IRequest<ChangeStatusAbilityTargetTypeDetailEngCommandResponse>
{
    public ChangeStatusAbilityTargetTypeDetailEngDto ChangeStatusAbilityTargetTypeDetailEngDto { get; set; }
}
