using Application.Feature.AbilityFeatures.AbilityTargetTypeDetailEng.Dto;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityTargetTypeDetailEng.Commands.Update;

public class UpdateAbilityTargetTypeDetailEngCommandRequest : IRequest<UpdateAbilityTargetTypeDetailEngCommandResponse>
{
    public UpdateAbilityTargetTypeDetailEngDto UpdateAbilityTargetTypeDetailEngDto { get; set; }
}
