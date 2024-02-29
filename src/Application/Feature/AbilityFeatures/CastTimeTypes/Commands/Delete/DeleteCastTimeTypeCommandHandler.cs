using Application.Feature.AbilityFeatures.CastTimeTypes.Rules;
using Application.Service.AbilityServices.CastTimeTypeService;
using AutoMapper;
using Domain.Abilities;
using MediatR;


namespace Application.Feature.AbilityFeatures.CastTimeTypes.Commands.Delete;

public class DeleteCastTimeTypeCommandHandler : IRequestHandler<DeleteCastTimeTypeCommandRequest, DeleteCastTimeTypeCommandResponse>
{
    private readonly ICastTimeTypeService _castTimeTypeService;
    private readonly CastTimeTypeBusinessRules _castTimeTypeBusinessRules;
    private readonly IMapper _mapper;

    public DeleteCastTimeTypeCommandHandler(ICastTimeTypeService castTimeTypeService, CastTimeTypeBusinessRules castTimeTypeBusinessRules, IMapper mapper)
    {
        _castTimeTypeService = castTimeTypeService;
        _castTimeTypeBusinessRules = castTimeTypeBusinessRules;
        _mapper = mapper;
    }

    public async Task<DeleteCastTimeTypeCommandResponse> Handle(DeleteCastTimeTypeCommandRequest request, CancellationToken cancellationToken)
    {
        // Ensure that the specified CastTimeType ID exists before attempting to delete
        await _castTimeTypeBusinessRules.IdShouldBeExist(request.DeleteCastTimeTypeDto.Id);

        // Retrieve the CastTimeType with the specified ID using CastTimeTypeService
        CastTimeType castTimeType = await _castTimeTypeService.GetById(request.DeleteCastTimeTypeDto.Id);

        // Mark the CastTimeType as deleted
        castTimeType.IsDeleted = true;

        // Set the status of the CastTimeType to false
        castTimeType.Status = false;

        // Set the deletion date of the CastTimeType to the current date and time
        castTimeType.DeletedDate = DateTime.Now;

        // Delete the CastTimeType by calling the _castTimeTypeService
        await _castTimeTypeService.Delete(castTimeType);

        // Map the deleted CastTimeType to the response DTO
        DeleteCastTimeTypeCommandResponse mappedResponse = _mapper.Map<DeleteCastTimeTypeCommandResponse>(castTimeType);

        // Return the mapped response to the calling code
        return mappedResponse;

    }
}
