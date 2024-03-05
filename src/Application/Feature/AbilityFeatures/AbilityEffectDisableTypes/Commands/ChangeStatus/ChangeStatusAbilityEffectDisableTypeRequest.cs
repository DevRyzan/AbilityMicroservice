using Application.Feature.AbilityFeatures.AbilityEffectDisableTypes.Dtos;
using MediatR;


namespace Application.Feature.AbilityFeatures.AbilityEffectDisableTypes.Commands.ChangeStatus;

public class ChangeStatusAbilityEffectDisableTypeRequest : IRequest<ChangeStatusAbilityEffectDisableTypeResponse>
{
    public ChangeStatusAbilityEffectDisableTypeDto ChangeStatusAbilityEffectDisableTypeDto { get; set; }
}
