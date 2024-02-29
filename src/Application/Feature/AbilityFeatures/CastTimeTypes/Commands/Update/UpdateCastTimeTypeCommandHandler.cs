using Application.Feature.AbilityFeatures.CastTimeTypes.Rules;
using Application.Service.AbilityServices.CastTimeTypeService;
using AutoMapper;
using Domain.Abilities;
using MediatR;


namespace Application.Feature.AbilityFeatures.CastTimeTypes.Commands.Update;

public class UpdateCastTimeTypeCommandHandler : IRequestHandler<UpdateCastTimeTypeCommandRequest, UpdateCastTimeTypeCommandResponse>
{
    private readonly ICastTimeTypeService _castTimeTypeService;
    private readonly CastTimeTypeBusinessRules _castTimeTypeBusinessRules;
    private readonly IMapper _mapper;

    public UpdateCastTimeTypeCommandHandler(ICastTimeTypeService castTimeTypeService, CastTimeTypeBusinessRules castTimeTypeBusinessRules, IMapper mapper)
    {
        _castTimeTypeService = castTimeTypeService;
        _castTimeTypeBusinessRules = castTimeTypeBusinessRules;
        _mapper = mapper;
    }

    public async Task<UpdateCastTimeTypeCommandResponse> Handle(UpdateCastTimeTypeCommandRequest request, CancellationToken cancellationToken)
    {
        // Ensure that the specified CastTimeType ID exists before attempting to update
        await _castTimeTypeBusinessRules.IdShouldBeExist(request.UpdateCastTimeTypeDto.Id);

        // Retrieve the CastTimeType with the specified ID using CastTimeTypeService
        CastTimeType castTimeType = await _castTimeTypeService.GetById(request.UpdateCastTimeTypeDto.Id);

        // Update the properties of the existing CastTimeType with the new data from the request
        castTimeType.Name = request.UpdateCastTimeTypeDto.Name;
        castTimeType.Description = request.UpdateCastTimeTypeDto.Description;

        // Set the updated date of the CastTimeType to the current date and time
        castTimeType.UpdatedDate = DateTime.Now;

        // Update the CastTimeType by calling the _castTimeTypeService
        await _castTimeTypeService.Update(castTimeType);

        // Map the updated CastTimeType to the response DTO
        UpdateCastTimeTypeCommandResponse mappedResponse = _mapper.Map<UpdateCastTimeTypeCommandResponse>(castTimeType);

        // Return the mapped response to the calling code
        return mappedResponse;

    }
}
