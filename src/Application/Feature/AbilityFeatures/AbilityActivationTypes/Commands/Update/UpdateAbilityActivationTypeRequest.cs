using Application.Feature.AbilityFeatures.AbilityActivationTypes.Dto;
using MediatR;


namespace Application.Feature.AbilityFeatures.AbilityActivationTypes.Commands.Update;

public class UpdateAbilityActivationTypeRequest : IRequest<UpdateAbilityActivationTypeResponse>
{
    public UpdateAbilityActivationTypeDto UpdateAbilityActivationTypeDto { get; set; }
}
