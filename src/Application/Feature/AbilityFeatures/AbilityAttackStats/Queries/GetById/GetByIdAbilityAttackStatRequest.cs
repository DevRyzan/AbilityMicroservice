using Application.Feature.AbilityFeatures.AbilityAttackStats.Dto;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityAttackStats.Queries.GetById;

public class GetByIdAbilityAttackStatRequest : IRequest<GetByIdAbilityAttackStatResponse>
{
    public GetByIdAbilityAttackStatDto GetByIdAbilityAttackStatDto { get; set; }
}
