using Application.Feature.AbilityFeatures.CastTimeTypes.Rules;
using Application.Service.AbilityServices.CastTimeTypeService;
using AutoMapper;
using Domain.Abilities;
using MediatR;


namespace Application.Feature.AbilityFeatures.CastTimeTypes.Commands.Remove;

public class RemoveCastTimeTypeCommandHandler : IRequestHandler<RemoveCastTimeTypeCommandRequest, RemoveCastTimeTypeCommandResponse>
{
    private readonly ICastTimeTypeService _castTimeTypeService;
    private readonly CastTimeTypeBusinessRules _castTimeTypeBusinessRules;
    private readonly IMapper _mapper;

    public RemoveCastTimeTypeCommandHandler(ICastTimeTypeService castTimeTypeService, CastTimeTypeBusinessRules castTimeTypeBusinessRules, IMapper mapper)
    {
        _castTimeTypeService = castTimeTypeService;
        _castTimeTypeBusinessRules = castTimeTypeBusinessRules;
        _mapper = mapper;
    }

    public async Task<RemoveCastTimeTypeCommandResponse> Handle(RemoveCastTimeTypeCommandRequest request, CancellationToken cancellationToken)
    {
        // Ensure that the specified CastTimeType ID exists before attempting to remove
        await _castTimeTypeBusinessRules.IdShouldBeExist(request.RemoveCastTimeTypeDto.Id);

        // Perform additional business rules specific to the removal process
        await _castTimeTypeBusinessRules.RemoveCondition(request.RemoveCastTimeTypeDto.Id);

        // Retrieve the CastTimeType with the specified ID using CastTimeTypeService
        CastTimeType castTimeType = await _castTimeTypeService.GetById(request.RemoveCastTimeTypeDto.Id);

        // Remove the CastTimeType by calling the _castTimeTypeService
        await _castTimeTypeService.Remove(castTimeType);

        // Map the removed CastTimeType to the response DTO
        RemoveCastTimeTypeCommandResponse mappedResponse = _mapper.Map<RemoveCastTimeTypeCommandResponse>(castTimeType);

        // Return the mapped response to the calling code
        return mappedResponse;


    }
}
