using Application.Feature.AbilityFeatures.AbilityTypes.Dtos;
using MediatR;


namespace Application.Feature.AbilityFeatures.AbilityTypes.Commands.Update;

public class UpdateAbilityTypeCommandRequest : IRequest<UpdateAbilityTypeCommandResponse>
{
    public UpdateAbilityTypeDto UpdateAbilityTypeDto { get; set; }
}
