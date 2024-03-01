using Application.Feature.AbilityFeatures.AbilityEffectTypes.Dtos;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityEffectTypes.Commands.ChangeStatus;

public class ChangeStatusAbilityEffectTypeRequest : IRequest<ChangeStatusAbilityEffectTypeResponse>
{
    public ChangeStatusAbilityEffectTypeDto ChangeStatusAbilityEffectTypeDto { get; set; }
}
