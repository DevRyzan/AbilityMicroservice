using Application.Feature.AbilityFeatures.AbilityTypes.Rules;
using Application.Service.AbilityServices.AbilityTypeService;
using AutoMapper;
using Domain.Abilities;
using MediatR;


namespace Application.Feature.AbilityFeatures.AbilityTypes.Commands.Delete;

public class DeleteAbilityTypeCommandHandler : IRequestHandler<DeleteAbilityTypeCommandRequest, DeleteAbilityTypeCommandResponse>
{
    private readonly IAbilityTypeService _abilityTypeService;
    private readonly AbilityTypeBusinessRules _abilityTypeBusinessRules;
    private readonly IMapper _mapper;

    public DeleteAbilityTypeCommandHandler(IAbilityTypeService abilityTypeService, AbilityTypeBusinessRules abilityTypeBusinessRules, IMapper mapper)
    {
        _abilityTypeService = abilityTypeService;
        _abilityTypeBusinessRules = abilityTypeBusinessRules;
        _mapper = mapper;
    }

    public async Task<DeleteAbilityTypeCommandResponse> Handle(DeleteAbilityTypeCommandRequest request, CancellationToken cancellationToken)
    {
        // Ensure that the specified AbilityType ID exists before attempting to delete
        await _abilityTypeBusinessRules.IdShouldBeExist(request.DeleteAbilityTypeDto.Id);

        // Retrieve the AbilityType with the specified ID using AbilityTypeService
        AbilityType abilityType = await _abilityTypeService.GetById(request.DeleteAbilityTypeDto.Id);

        // Mark the AbilityType as deleted
        abilityType.IsDeleted = true;

        // Set the status of the AbilityType to false
        abilityType.Status = false;

        // Set the deletion date of the AbilityType to the current date and time
        abilityType.DeletedDate = DateTime.Now;

        // Delete the AbilityType by calling the _abilityTypeService
        await _abilityTypeService.Delete(abilityType);

        // Map the deleted AbilityType to the response DTO
        DeleteAbilityTypeCommandResponse mappedResponse = _mapper.Map<DeleteAbilityTypeCommandResponse>(abilityType);

        // Return the mapped response to the calling code
        return mappedResponse;

    }
}
