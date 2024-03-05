using Application.Feature.AbilityFeatures.AbilityDamageTypes.Dtos;
using MediatR;


namespace Application.Feature.AbilityFeatures.AbilityDamageTypes.Queries.GetById;

public class GetByIdAbilityDamageTypeRequest : IRequest<GetByIdAbilityDamageTypeResponse>
{
    public GetByIdAbilityDamageTypeDto GetByIdAbilityDamageTypeDto { get; set; }
}
