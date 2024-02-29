using Core.Application.Requests;
using MediatR;


namespace Application.Feature.AbilityFeatures.CastTimeTypes.Queries.GetListByActive;

public class GetListByActiveCastTimeTypeRequest : IRequest<List<GetListByActiveCastTimeTypeResponse>>
{
    public PageRequest PageRequest { get; set; }
}
