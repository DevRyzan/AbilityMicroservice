using Application.Feature.AbilityFeatures.AbilityLevelDetailEng.Dto;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityLevelDetailEng.Commands.Update;

public class UpdateAbilityLevelDetailEngCommandRequest : IRequest<UpdateAbilityLevelDetailEngCommandResponse>
{
    public UpdateAbilityLevelDetailEngDto UpdateAbilityLevelDetailEngDto { get; set; }
}
