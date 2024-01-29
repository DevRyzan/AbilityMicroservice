using Application.Feature.AbilityFeatures.AbilityCombo.Dto;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityCombo.Commands.Update;

public class UpdateAbilityComboCommandRequest : IRequest<UpdateAbilityComboCommandResponse>
{
    public UpdateAbilityComboDto UpdateAbilityComboDto { get; set; }
}
