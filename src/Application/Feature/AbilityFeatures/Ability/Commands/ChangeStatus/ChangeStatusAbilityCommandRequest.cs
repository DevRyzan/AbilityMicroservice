using Application.Feature.AbilityFeatures.Ability.Dtos;
using MediatR;

namespace Application.Feature.AbilityFeatures.Ability.Commands.ChangeStatus;

public class ChangeStatusAbilityCommandRequest : IRequest<ChangeStatusAbilityCommandResponse>
{
    
    public ChangeStatusAbilityDto ChangeStatusAbilityDto { get; set; }


}
