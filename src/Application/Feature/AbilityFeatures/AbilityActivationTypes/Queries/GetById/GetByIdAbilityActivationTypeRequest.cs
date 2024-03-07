
using Application.Feature.AbilityFeatures.AbilityActivationTypes.Dto;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityActivationTypes.Queries.GetById;

public class GetByIdAbilityActivationTypeRequest : IRequest<GetByIdAbilityActivationTypeResponse>
{
    public GetByIdAbilityActivationTypeDto GetByIdAbilityActivationTypeDto { get; set; }
}
