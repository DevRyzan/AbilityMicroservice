using Application.Feature.AbilityFeatures.AbilityAffectUnits.Dto;
using MediatR;


namespace Application.Feature.AbilityFeatures.AbilityAffectUnits.Commands.Delete;

public class DeleteAbilityAffectUnitRequest : IRequest<DeleteAbilityAffectUnitResponse>
{
    public DeleteAbilityAffectUnitDto DeleteAbilityAffectUnitDto { get; set; }
}
