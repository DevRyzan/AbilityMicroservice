using Application.Feature.AbilityFeatures.CastTimeTypes.Rules;
using Application.Service.AbilityServices.CastTimeTypeService;
using AutoMapper;
using Domain.Abilities;
using MediatR;

namespace Application.Feature.AbilityFeatures.CastTimeTypes.Queries.GetListByActive;

public class GetListByActiveCastTimeTypeHandler : IRequestHandler<GetListByActiveCastTimeTypeRequest, List<GetListByActiveCastTimeTypeResponse>>
{
    private readonly ICastTimeTypeService _castTimeTypeService;
    private readonly CastTimeTypeBusinessRules _castTimeTypeBusinessRules;
    private readonly IMapper _mapper;

    public GetListByActiveCastTimeTypeHandler(ICastTimeTypeService castTimeTypeService, CastTimeTypeBusinessRules castTimeTypeBusinessRules, IMapper mapper)
    {
        _castTimeTypeService = castTimeTypeService;
        _castTimeTypeBusinessRules = castTimeTypeBusinessRules;
        _mapper = mapper;
    }

    public async Task<List<GetListByActiveCastTimeTypeResponse>> Handle(GetListByActiveCastTimeTypeRequest request, CancellationToken cancellationToken)
    {
        await _castTimeTypeBusinessRules.PageRequestShouldBeValid(request.PageRequest.Page, request.PageRequest.PageSize);

        List<CastTimeType> listOfCastTimeTypes = await _castTimeTypeService.GetActiveList(index: request.PageRequest.Page, size: request.PageRequest.PageSize);

        List<GetListByActiveCastTimeTypeResponse> mappedResponse = _mapper.Map<List<GetListByActiveCastTimeTypeResponse>>(listOfCastTimeTypes);
        return mappedResponse;


    }
}
