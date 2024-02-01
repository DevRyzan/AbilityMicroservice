using Application.Feature.AbilityFeatures.Ability.Dtos;
using MediatR;

namespace Application.Feature.AbilityFeatures.Ability.Commands.Update;

public class UpdateAbilityCommandRequest : IRequest<UpdateAbilityCommandResponse>
{
    public UpdateAbilityDto UpdateAbilityDto { get; set; }
}
