using Application.Feature.AbilityFeatures.AbilityAffectUnits.Dto;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityAffectUnits.Commands.Create;

public class CreateAbilityAffectUnitRequest : IRequest<CreateAbilityAffectUnitResponse>
{
    public CreateAbilityAffectUnitDto CreateAbilityAffectUnitDto { get; set; }
}
