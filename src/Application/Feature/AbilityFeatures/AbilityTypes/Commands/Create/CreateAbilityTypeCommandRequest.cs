using Application.Feature.AbilityFeatures.AbilityTypes.Dtos;
using MediatR;


namespace Application.Feature.AbilityFeatures.AbilityTypes.Commands.Create;

public class CreateAbilityTypeCommandRequest : IRequest<CreateAbilityTypeCommandResponse>
{
    public CreateAbilityTypeDto CreateAbilityTypeDto { get; set; }
}
