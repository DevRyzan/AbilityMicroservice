using Application.Feature.AbilityFeatures.CastTimeTypes.Rules;
using Application.Service.AbilityServices.CastTimeTypeService;
using AutoMapper;
using Domain.Abilities;
using MediatR;


namespace Application.Feature.AbilityFeatures.CastTimeTypes.Queries.GetById;

public class GetByIdCastTimeTypeQueryHandler : IRequestHandler<GetByIdCastTimeTypeQueryRequest, GetByIdCastTimeTypeQueryResponse>
{
    private readonly ICastTimeTypeService _castTimeTypeService;
    private readonly CastTimeTypeBusinessRules _castTimeTypeBusinessRules;
    private readonly IMapper _mapper;

    public GetByIdCastTimeTypeQueryHandler(ICastTimeTypeService castTimeTypeService, CastTimeTypeBusinessRules castTimeTypeBusinessRules, IMapper mapper)
    {
        _castTimeTypeService = castTimeTypeService;
        _castTimeTypeBusinessRules = castTimeTypeBusinessRules;
        _mapper = mapper;
    }

    public async Task<GetByIdCastTimeTypeQueryResponse> Handle(GetByIdCastTimeTypeQueryRequest request, CancellationToken cancellationToken)
    {
        await _castTimeTypeBusinessRules.IdShouldBeExist(request.GetByIdCastTimeTypeDto.Id);

        CastTimeType castTimeType = await _castTimeTypeService.GetById(request.GetByIdCastTimeTypeDto.Id);

        GetByIdCastTimeTypeQueryResponse mappedResponse = _mapper.Map<GetByIdCastTimeTypeQueryResponse>(castTimeType);
        return mappedResponse;

    }
}
