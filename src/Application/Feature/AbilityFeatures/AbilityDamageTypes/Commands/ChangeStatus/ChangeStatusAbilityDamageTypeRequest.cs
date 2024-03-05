using Application.Feature.AbilityFeatures.AbilityDamageTypes.Dtos;
using MediatR;


namespace Application.Feature.AbilityFeatures.AbilityDamageTypes.Commands.ChangeStatus;

public class ChangeStatusAbilityDamageTypeRequest : IRequest<ChangeStatusAbilityDamageTypeResponse>
{
    public ChangeStatusAbilityDamageTypeDto ChangeStatusAbilityDamageTypeDto { get; set; }
}
