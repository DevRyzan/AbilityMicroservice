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
        // Ensure that the specified page request is valid before attempting to retrieve data
        await _castTimeTypeBusinessRules.PageRequestShouldBeValid(request.PageRequest.Page, request.PageRequest.PageSize);

        // Retrieve a list of active CastTimeTypes based on the provided page and page size
        List<CastTimeType> listOfCastTimeTypes = await _castTimeTypeService.GetActiveList(index: request.PageRequest.Page, size: request.PageRequest.PageSize);

        // Map the list of CastTimeTypes to the response DTO list
        List<GetListByActiveCastTimeTypeResponse> mappedResponse = _mapper.Map<List<GetListByActiveCastTimeTypeResponse>>(listOfCastTimeTypes);

        // Return the mapped response list to the calling code
        return mappedResponse;

    }
}
