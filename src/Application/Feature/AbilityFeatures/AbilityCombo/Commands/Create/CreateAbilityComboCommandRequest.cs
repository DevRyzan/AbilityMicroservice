using Application.Feature.AbilityFeatures.AbilityCombo.Dto;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityCombo.Commands.Create;

public class CreateAbilityComboCommandRequest : IRequest<CreateAbilityComboCommandResponse>
{
    public CreateAbilityComboDto CreateAbilityComboDto { get; set; }
}
