using Core.Application.Caching;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityCategory.Queries.GetById;

public class GetByIdAbilityCategoryQueryRequest : IRequest<GetByIdAbilityCategoryQueryResponse>
{
    public Guid Id { get; set; }
}
