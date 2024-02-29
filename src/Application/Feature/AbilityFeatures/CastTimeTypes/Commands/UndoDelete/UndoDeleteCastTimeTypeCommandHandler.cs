using Application.Feature.AbilityFeatures.CastTimeTypes.Rules;
using Application.Service.AbilityServices.CastTimeTypeService;
using AutoMapper;
using Domain.Abilities;
using MediatR;

namespace Application.Feature.AbilityFeatures.CastTimeTypes.Commands.UndoDelete;

public class UndoDeleteCastTimeTypeCommandHandler : IRequestHandler<UndoDeleteCastTimeTypeCommandRequest, UndoDeleteCastTimeTypeCommandResponse>
{
    private readonly ICastTimeTypeService _castTimeTypeService;
    private readonly CastTimeTypeBusinessRules _castTimeTypeBusinessRules;
    private readonly IMapper _mapper;

    public UndoDeleteCastTimeTypeCommandHandler(ICastTimeTypeService castTimeTypeService, CastTimeTypeBusinessRules castTimeTypeBusinessRules, IMapper mapper)
    {
        _castTimeTypeService = castTimeTypeService;
        _castTimeTypeBusinessRules = castTimeTypeBusinessRules;
        _mapper = mapper;
    }

    public async Task<UndoDeleteCastTimeTypeCommandResponse> Handle(UndoDeleteCastTimeTypeCommandRequest request, CancellationToken cancellationToken)
    {
        // Ensure that the specified CastTimeType ID exists before attempting to undo the deletion
        await _castTimeTypeBusinessRules.IdShouldBeExist(request.UndoDeleteCastTimeTypeDto.Id);

        // Retrieve the CastTimeType with the specified ID using CastTimeTypeService
        CastTimeType castTimeType = await _castTimeTypeService.GetById(request.UndoDeleteCastTimeTypeDto.Id);

        // Undo the deletion by setting IsDeleted to false
        castTimeType.IsDeleted = false;

        // Set the updated date of the CastTimeType to the current date and time
        castTimeType.UpdatedDate = DateTime.Now;

        // Update the CastTimeType by calling the _castTimeTypeService
        await _castTimeTypeService.Update(castTimeType);

        // Map the updated CastTimeType to the response DTO
        UndoDeleteCastTimeTypeCommandResponse mappedResponse = _mapper.Map<UndoDeleteCastTimeTypeCommandResponse>(castTimeType);

        // Return the mapped response to the calling code
        return mappedResponse;

    }
}
