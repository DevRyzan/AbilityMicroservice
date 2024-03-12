
using Application.Feature.AbilityFeatures.AbilitySelfEffectStats.Dtos;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilitySelfEffectStats.Queries.GetById;

public class GetByIdAbilitySelfEffectStatRequest : IRequest<GetByIdAbilitySelfEffectStatResponse>
{
    public GetByIdAbilitySelfEffectStatDto GetByIdAbilitySelfEffectStatDto { get; set; }
}
