using Application.Feature.AbilityFeatures.AbilityActivationTypes.Dto;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityActivationTypes.Commands.ChangeStatus;

public class ChangeStatusAbilityActivationTypeRequest : IRequest<ChangeStatusAbilityActivationTypeResponse>
{
    public ChangeStatusAbilityActivationTypeDto ChangeStatusAbilityActivationTypeDto { get; set; }
}
