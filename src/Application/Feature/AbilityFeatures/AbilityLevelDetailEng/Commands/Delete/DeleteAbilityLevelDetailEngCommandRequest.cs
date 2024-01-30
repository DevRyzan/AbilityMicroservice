using Application.Feature.AbilityFeatures.AbilityLevelDetailEng.Dto;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityLevelDetailEng.Commands.Delete;

public class DeleteAbilityLevelDetailEngCommandRequest : IRequest<DeleteAbilityLevelDetailEngCommandResponse>
{
    public DeleteAbilityLevelDetailEngDto DeleteAbilityLevelDetailEngDto { get; set; }
}
