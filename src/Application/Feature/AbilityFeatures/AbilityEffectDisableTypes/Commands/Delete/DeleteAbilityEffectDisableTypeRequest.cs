using Application.Feature.AbilityFeatures.AbilityEffectDisableTypes.Dtos;
using MediatR;


namespace Application.Feature.AbilityFeatures.AbilityEffectDisableTypes.Commands.Delete;

public class DeleteAbilityEffectDisableTypeRequest : IRequest<DeleteAbilityEffectDisableTypeResponse>
{
    public DeleteAbilityEffectDisableTypeDto DeleteAbilityEffectDisableTypeDto { get; set; }
}
