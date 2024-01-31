using Application.Feature.AbilityFeatures.AbilityLevelDetailEng.Dto;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityLevelDetailEng.Queries.GetById;

public class GetByIdAbilityLevelDetailEngCommandRequest : IRequest<GetByIdAbilityLevelDetailEngCommandResponse>
{
    public GetByIdAbilityLevelDetailEngDto GetByIdAbilityLevelDetailEngDto { get; set; }
}
