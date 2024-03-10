using Application.Feature.AbilityFeatures.AbilityEffectStats.Dtos;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityEffectStats.Queries.GetById;

public class GetByIdAbilityEffectStatRequest : IRequest<GetByIdAbilityEffectStatResponse>
{
    public GetByIdAbilityEffectStatDto GetByIdAbilityEffectStatDto { get; set; }
}
