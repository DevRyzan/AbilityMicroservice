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
        // Ensure that the specified CastTimeType ID exists before attempting to retrieve
        await _castTimeTypeBusinessRules.IdShouldBeExist(request.GetByIdCastTimeTypeDto.Id);

        // Retrieve the CastTimeType with the specified ID using CastTimeTypeService
        CastTimeType castTimeType = await _castTimeTypeService.GetById(request.GetByIdCastTimeTypeDto.Id);

        // Map the retrieved CastTimeType to the response DTO
        GetByIdCastTimeTypeQueryResponse mappedResponse = _mapper.Map<GetByIdCastTimeTypeQueryResponse>(castTimeType);

        // Return the mapped response to the calling code
        return mappedResponse;

    }
}
