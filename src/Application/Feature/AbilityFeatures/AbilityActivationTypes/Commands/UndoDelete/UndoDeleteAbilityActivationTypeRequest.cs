using Application.Feature.AbilityFeatures.AbilityActivationTypes.Dto;
using MediatR;


namespace Application.Feature.AbilityFeatures.AbilityActivationTypes.Commands.UndoDelete;

public class UndoDeleteAbilityActivationTypeRequest : IRequest<UndoDeleteAbilityActivationTypeResponse>
{
    public UndoDeleteAbilityActivationTypeDto UndoDeleteAbilityActivationTypeDto { get; set; }
}
