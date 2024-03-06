using Application.Feature.AbilityFeatures.AbilityAffectUnits.Dto;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityAffectUnits.Commands.Update;

public class UpdateAbilityAffectUnitRequest : IRequest<UpdateAbilityAffectUnitResponse>
{
    public UpdateAbilityAffectUnitDto UpdateAbilityAffectUnitDto { get; set; }
}
