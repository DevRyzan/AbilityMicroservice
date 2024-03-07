using Application.Feature.AbilityFeatures.AbilityActivationTypes.Dto;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityActivationTypes.Commands.Create;

public class CreateAbilityActivationTypeRequest : IRequest<CreateAbilityActivationTypeResponse>
{
    public CreateAbilityActivationTypeDto CreateAbilityActivationTypeDto { get; set; }
}
