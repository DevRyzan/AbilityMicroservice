using Application.Feature.AbilityFeatures.AbilityLevelDetailEng.Dto;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityLevelDetailEng.Commands.ChangeStatus;

public class ChangeStatusAbilityLevelDetailEngCommandRequest : IRequest<ChangeStatusAbilityLevelDetailEngCommandResponse>
{
    public ChangeStatusAbilityLevelDetailEngDto ChangeStatusAbilityLevelDetailEng { get; set; }
}
