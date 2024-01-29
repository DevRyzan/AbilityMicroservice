using Application.Feature.AbilityFeatures.AbilityCombo.Dto;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityCombo.Queries.GetById;

public class GetByIdAbilityComboQueryRequest : IRequest<GetByIdAbilityComboQueryResponse>
{
    public GetByIdAbilityComboDto GetByIdAbilityComboDto { get; set; }
}
