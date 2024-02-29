using Core.Application.Requests;
using MediatR;


namespace Application.Feature.AbilityFeatures.CastTimeTypes.Queries.GetListByInActive;

public class GetListByInActiveCastTimeTypeRequest : IRequest<List<GetListByInActiveCastTimeTypeResponse>>
{
    public PageRequest PageRequest { get; set; }

}
