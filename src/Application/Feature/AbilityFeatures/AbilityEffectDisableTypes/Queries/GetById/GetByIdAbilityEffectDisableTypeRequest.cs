using Application.Feature.AbilityFeatures.AbilityEffectDisableTypes.Dtos;
using MediatR;


namespace Application.Feature.AbilityFeatures.AbilityEffectDisableTypes.Queries.GetById;

public class GetByIdAbilityEffectDisableTypeRequest : IRequest<GetByIdAbilityEffectDisableTypeResponse>
{
    public GetByIdAbilityEffectDisableTypeDto GetByIdAbilityEffectDisableTypeDto { get; set; }
}
