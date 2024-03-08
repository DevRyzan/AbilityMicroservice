using Application.Feature.AbilityFeatures.AbilityEffects.Dtos;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityEffects.Queries.GetById;

public class GetByIdAbilityEffectRequest : IRequest<GetByIdAbilityEffectResponse>
{
    public GetByIdAbilityEffectDto GetByIdAbilityEffectDto { get; set; }
}
