using Application.Feature.AbilityFeatures.AbilityLevelDetailEng.Dto;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityLevelDetailEng.Commands.Create;

public class CreateAbilityLevelDetailEngCommandRequest : IRequest<CreateAbilityLevelDetailEngCommandResponse>
{
    public CreateAbilityLevelDetailEngDto CreateAbilityLevelDetailEng { get; set; }
}
