using Application.Feature.AbilityFeatures.AbilityCombo.Dto;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityCombo.Commands.Remove;

public class RemoveAbilityComboCommandRequest : IRequest<RemoveAbilityComboCommandResponse>
{
    public RemoveAbilityComboDto RemoveAbilityComboDto { get; set; }
}
