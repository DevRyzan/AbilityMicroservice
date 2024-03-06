using Application.Feature.AbilityFeatures.AbilityAffectUnits.Dto;
using MediatR;


namespace Application.Feature.AbilityFeatures.AbilityAffectUnits.Commands.Remove;

public class RemoveAbilityAffectUnitRequest : IRequest<RemoveAbilityAffectUnitResponse>
{
    public RemoveAbilityAffectUnitDto RemoveAbilityAffectUnitDto { get; set; }
}
