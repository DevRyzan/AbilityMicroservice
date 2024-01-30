using Application.Feature.AbilityFeatures.AbilityLevelDetailEng.Dto;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityLevelDetailEng.Queries.GetByAbilityId;

public class GetByAbilityIdAbilityLevelDetailEngCommandRequest : IRequest<GetByAbilityIdAbilityLevelDetailEngCommandResponse>
{
    public GetByAbilityLevelIdAbilityLevelDetailEngDto GetByAbilityIdAbilityLevelDetailEngDto { get; set; }
}
