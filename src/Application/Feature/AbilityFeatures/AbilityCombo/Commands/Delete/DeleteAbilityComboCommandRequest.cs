using Application.Feature.AbilityFeatures.AbilityCombo.Dto;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityCombo.Commands.Delete;

public class DeleteAbilityComboCommandRequest : IRequest<DeleteAbilityComboCommandResponse>
{
    public DeleteAbilityComboDto DeleteAbilityComboDto { get; set; }
}
