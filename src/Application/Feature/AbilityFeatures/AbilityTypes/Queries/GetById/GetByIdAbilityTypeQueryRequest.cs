
using Application.Feature.AbilityFeatures.AbilityTypes.Dtos;
using MediatR;


namespace Application.Feature.AbilityFeatures.AbilityTypes.Queries.GetById;

public class GetByIdAbilityTypeQueryRequest : IRequest<GetByIdAbilityTypeQueryResponse>
{
    public GetByIdAbilityEffectTypeDto GetByIdAbilityTypeDto { get; set; }
}
