using Application.Feature.AbilityFeatures.CastTimeTypes.Rules;
using Application.Service.AbilityServices.CastTimeTypeService;
using AutoMapper;
using Domain.Abilities;
using MediatR;


namespace Application.Feature.AbilityFeatures.CastTimeTypes.Queries.GetListByInActive;

public class GetListByInActiveCastTimeTypeHandler : IRequestHandler<GetListByInActiveCastTimeTypeRequest, List<GetListByInActiveCastTimeTypeResponse>>
{
    private readonly ICastTimeTypeService _castTimeTypeService;
    private readonly CastTimeTypeBusinessRules _castTimeTypeBusinessRules;
    private readonly IMapper _mapper;

    public GetListByInActiveCastTimeTypeHandler(ICastTimeTypeService castTimeTypeService, CastTimeTypeBusinessRules castTimeTypeBusinessRules, IMapper mapper)
    {
        _castTimeTypeService = castTimeTypeService;
        _castTimeTypeBusinessRules = castTimeTypeBusinessRules;
        _mapper = mapper;
    }

    public async Task<List<GetListByInActiveCastTimeTypeResponse>> Handle(GetListByInActiveCastTimeTypeRequest request, CancellationToken cancellationToken)
    {
        await _castTimeTypeBusinessRules.PageRequestShouldBeValid(request.PageRequest.Page, request.PageRequest.PageSize);

        List<CastTimeType> listOfCastTimeTypes = await _castTimeTypeService.GetInActiveList(index: request.PageRequest.Page, size: request.PageRequest.PageSize);

        List<GetListByInActiveCastTimeTypeResponse> mappedResponse = _mapper.Map<List<GetListByInActiveCastTimeTypeResponse>>(listOfCastTimeTypes);
        return mappedResponse;
    }
}
