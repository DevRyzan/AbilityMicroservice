using Application.Feature.AbilityFeatures.Ability.Dtos;
using MediatR;

namespace Application.Feature.AbilityFeatures.Ability.Commands.Create;

public class CreateAbilityCommandRequest : IRequest<CreateAbilityCommandResponse>
{
    public CreateAbilityDto CreateAbilityDto { get; set; }
}
