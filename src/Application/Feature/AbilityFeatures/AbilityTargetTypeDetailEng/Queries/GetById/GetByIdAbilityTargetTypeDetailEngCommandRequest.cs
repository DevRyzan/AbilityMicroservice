using Application.Feature.AbilityFeatures.AbilityTargetTypeDetailEng.Dto;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityTargetTypeDetailEng.Queries.GetById;

public class GetByIdAbilityTargetTypeDetailEngCommandRequest : IRequest<GetByIdAbilityTargetTypeDetailEngCommandResponse>
{
    public GetByIdAbilityTargetTypeDetailEngDto GetByIdAbilityTargetTypeDetailEngDto { get; set; }
}
