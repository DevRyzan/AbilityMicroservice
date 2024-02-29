using Application.Feature.AbilityFeatures.CastTimeTypes.Dtos;
using MediatR;


namespace Application.Feature.AbilityFeatures.CastTimeTypes.Queries.GetById;

public class GetByIdCastTimeTypeQueryRequest : IRequest<GetByIdCastTimeTypeQueryResponse>
{
    public GetByIdCastTimeTypeDto GetByIdCastTimeTypeDto { get; set; }
}
