using Application.Feature.AbilityFeatures.AbilityTargetTypeDetailEng.Dto;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityTargetTypeDetailEng.Commands.Create;

public class CreateAbilityTargetTypeDetailEngCommandRequest : IRequest<CreateAbilityTargetTypeDetailEngCommandResponse>
{
    public CreateAbilityTargetTypeDetailEngDto CreateAbilityTargetTypeDetailEngDto { get; set; }
}
