using Application.Feature.AbilityFeatures.AbilityActivationTypes.Dto;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityActivationTypes.Commands.Delete;

public class DeleteAbilityActivationTypeRequest : IRequest<DeleteAbilityActivationTypeResponse>
{
    public DeleteAbilityActivationTypeDto DeleteAbilityActivationTypeDto { get; set; }
}
