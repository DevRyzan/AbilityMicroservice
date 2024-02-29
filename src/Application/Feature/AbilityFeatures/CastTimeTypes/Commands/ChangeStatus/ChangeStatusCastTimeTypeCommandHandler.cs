using Application.Feature.AbilityFeatures.CastTimeTypes.Rules;
using Application.Service.AbilityServices.CastTimeTypeService;
using AutoMapper;
using Domain.Abilities;
using MediatR;


namespace Application.Feature.AbilityFeatures.CastTimeTypes.Commands.ChangeStatus;

public class ChangeStatusCastTimeTypeCommandHandler : IRequestHandler<ChangeStatusCastTimeTypeCommandRequest, ChangeStatusCastTimeTypeCommandResponse>
{
    private readonly ICastTimeTypeService _castTimeTypeService;
    private readonly CastTimeTypeBusinessRules _castTimeTypeBusinessRules;
    private readonly IMapper _mapper;

    public ChangeStatusCastTimeTypeCommandHandler(ICastTimeTypeService castTimeTypeService, CastTimeTypeBusinessRules castTimeTypeBusinessRules, IMapper mapper)
    {
        _castTimeTypeService = castTimeTypeService;
        _castTimeTypeBusinessRules = castTimeTypeBusinessRules;
        _mapper = mapper;
    }

    public async Task<ChangeStatusCastTimeTypeCommandResponse> Handle(ChangeStatusCastTimeTypeCommandRequest request, CancellationToken cancellationToken)
    {
        // Check if the specified CastTimeType ID exists
        await _castTimeTypeBusinessRules.IdShouldBeExist(request.ChangeStatusCastTimeTypeDto.Id);

        // Retrieve the CastTimeType with the specified ID using CastTimeTypeService
        CastTimeType castTimeType = await _castTimeTypeService.GetById(request.ChangeStatusCastTimeTypeDto.Id);

        // Toggle the status of CastTimeType (switch between true and false)
        castTimeType.Status = castTimeType.Status == true ? false : true;

        // Set the updated date of CastTimeType to the current date and time
        castTimeType.UpdatedDate = DateTime.Now;

        // Update CastTimeType using CastTimeTypeService
        await _castTimeTypeService.Update(castTimeType);

        // Map the updated CastTimeType to the response DTO
        ChangeStatusCastTimeTypeCommandResponse mappedResponse = _mapper.Map<ChangeStatusCastTimeTypeCommandResponse>(castTimeType);

        // Return the mapped response to the calling code
        return mappedResponse;
    }
}
