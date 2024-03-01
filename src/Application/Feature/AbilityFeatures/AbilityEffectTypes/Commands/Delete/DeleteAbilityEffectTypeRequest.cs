using Application.Feature.AbilityFeatures.AbilityEffectTypes.Dtos;
using MediatR;


namespace Application.Feature.AbilityFeatures.AbilityEffectTypes.Commands.Delete;

public class DeleteAbilityEffectTypeRequest : IRequest<DeleteAbilityEffectTypeResponse>
{
    public DeleteAbilityEffectTypeDto DeleteAbilityEffectTypeDto{ get; set; }
}
