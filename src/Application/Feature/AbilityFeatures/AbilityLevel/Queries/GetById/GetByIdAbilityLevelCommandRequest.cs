using Application.Feature.AbilityFeatures.AbilityLevel.Dto;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityLevel.Queries.GetById;

public class GetByIdAbilityLevelCommandRequest : IRequest<GetByIdAbilityLevelCommandResponse>
{
    public GetByIdAbilityLevelDto GetByIdAbilityLevelDto { get; set; }
}
