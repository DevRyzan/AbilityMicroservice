using Application.Feature.AbilityFeatures.AbilityCombo.Dto;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityCombo.Commands.ChangeStatus;

public class ChangeStatusAbilityComboCommandRequest : IRequest<ChangeStatusAbilityComboCommandResponse>
{
    public ChangeStatusAbilityComboDto ChangeStatusAbilityComboDto { get; set; }
}
