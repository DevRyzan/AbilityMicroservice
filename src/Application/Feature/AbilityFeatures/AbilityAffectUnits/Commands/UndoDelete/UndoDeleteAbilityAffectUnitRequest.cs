using Application.Feature.AbilityFeatures.AbilityAffectUnits.Dto;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityAffectUnits.Commands.UndoDelete;

public class UndoDeleteAbilityAffectUnitRequest : IRequest<UndoDeleteAbilityAffectUnitResponse>
{
    public UndoDeleteAbilityAffectUnitDto UndoDeleteAbilityAffectUnitDto { get; set; }
}
