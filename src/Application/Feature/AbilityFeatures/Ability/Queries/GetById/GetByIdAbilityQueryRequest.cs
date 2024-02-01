using Application.Feature.AbilityFeatures.Ability.Dtos;
using MediatR;

namespace Application.Feature.AbilityFeatures.Ability.Queries.GetById;

public class GetByIdAbilityQueryRequest : IRequest<GetByIdAbilityQueryResponse>
{
    public GetByIdAbilityDto GetByIdAbilityDto { get; set; }
}
