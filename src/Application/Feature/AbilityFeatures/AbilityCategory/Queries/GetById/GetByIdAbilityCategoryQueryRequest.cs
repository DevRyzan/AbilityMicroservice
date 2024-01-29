using Application.Feature.AbilityFeatures.AbilityCategory.Dto;
using Core.Application.Caching;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityCategory.Queries.GetById;

public class GetByIdAbilityCategoryQueryRequest : IRequest<GetByIdAbilityCategoryQueryResponse>
{
    public AbilityCategoryGetByIdDto AbilityCategoryGetByIdDto { get; set; }
}
