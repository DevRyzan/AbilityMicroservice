using Application.Feature.AbilityFeatures.AbilityAffectUnits.Dto;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityAffectUnits.Queries.GetById;

public class GetByIdAbilityAffectUnitRequest : IRequest<GetByIdAbilityAffectUnitResponse>
{
    public GetByIdAbilityAffectUnitDto GetByIdAbilityAffectUnitDto { get; set; }
}
