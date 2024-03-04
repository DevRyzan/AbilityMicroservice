using Application.Feature.AbilityFeatures.AbilityEffectTypes.Dtos;
using MediatR;


namespace Application.Feature.AbilityFeatures.AbilityEffectTypes.Queries.GetById;

public class GetByIdAbilityEffectTypeRequest : IRequest<GetByIdAbilityEffectTypeResponse>
{
    public GetByIdAbilityEffectTypeDto GetByIdAbilityEffectTypeDto { get; set; }
}
