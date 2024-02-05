using Application.Feature.AbilityFeatures.AbilityTargetTypeDetailEng.Dto;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityTargetTypeDetailEng.Commands.Delete;

public class DeleteAbilityTargetTypeDetailEngCommandRequest : IRequest<DeleteAbilityTargetTypeDetailEngCommandResponse>
{
    public DeleteAbilityTargetTypeDetailEngDto DeleteAbilityTargetTypeDetailEngDto { get; set; }
}
