using Application.Feature.AbilityFeatures.AbilityTypes.Dtos;
using MediatR;


namespace Application.Feature.AbilityFeatures.AbilityTypes.Commands.ChangeStatus;

public class ChangeStatusAbilityTypeCommandRequest : IRequest<ChangeStatusAbilityTypeCommandResponse>
{
    public ChangeStatusAbilityTypeDto ChangeStatusAbilityTypeDto { get; set; }
}
