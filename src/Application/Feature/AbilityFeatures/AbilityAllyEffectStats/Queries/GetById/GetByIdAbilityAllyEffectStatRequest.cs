using Application.Feature.AbilityFeatures.AbilityAllyEffectStats.Dto;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityAllyEffectStats.Queries.GetById;

public class GetByIdAbilityAllyEffectStatRequest : IRequest<GetByIdAbilityAllyEffectStatResponse>
{
    public GetByIdAbilityAllyEffectStatDto GetByIdAbilityAllyEffectStatDto { get; set; }
}
