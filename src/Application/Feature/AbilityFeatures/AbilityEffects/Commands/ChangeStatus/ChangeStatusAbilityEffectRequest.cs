using Application.Feature.AbilityFeatures.AbilityEffects.Dtos;
using MediatR;


namespace Application.Feature.AbilityFeatures.AbilityEffects.Commands.ChangeStatus;

public class ChangeStatusAbilityEffectRequest : IRequest<ChangeStatusAbilityEffectResponse>
{
    public ChangeStatusAbilityEffectDto ChangeStatusAbilityEffectDto { get; set; }

}
