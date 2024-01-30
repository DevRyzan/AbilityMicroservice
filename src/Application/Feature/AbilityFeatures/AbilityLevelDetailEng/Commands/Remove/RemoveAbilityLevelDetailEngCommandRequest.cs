using Application.Feature.AbilityFeatures.AbilityLevelDetailEng.Dto;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityLevelDetailEng.Commands.Remove;

public class RemoveAbilityLevelDetailEngCommandRequest : IRequest<RemoveAbilityLevelDetailEngCommandResponse>
{
    public RemoveAbilityLevelDetailEngDto RemoveAbilityLevelDetailEngDto { get; set; }
}
