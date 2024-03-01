using Application.Feature.AbilityFeatures.AbilityTypes.Rules;
using Application.Service.AbilityServices.AbilityTypeService;
using AutoMapper;
using Domain.Abilities;
using MediatR;


namespace Application.Feature.AbilityFeatures.AbilityTypes.Commands.ChangeStatus;

public class ChangeStatusAbilityTypeCommandHandler : IRequestHandler<ChangeStatusAbilityTypeCommandRequest, ChangeStatusAbilityTypeCommandResponse>
{
    private readonly IAbilityTypeService _abilityTypeService;
    private readonly AbilityTypeBusinessRules _abilityTypeBusinessRules;
    private readonly IMapper _mapper;

    public ChangeStatusAbilityTypeCommandHandler(IAbilityTypeService abilityTypeService, AbilityTypeBusinessRules abilityTypeBusinessRules, IMapper mapper)
    {
        _abilityTypeService = abilityTypeService;
        _abilityTypeBusinessRules = abilityTypeBusinessRules;
        _mapper = mapper;
    }

    public async Task<ChangeStatusAbilityTypeCommandResponse> Handle(ChangeStatusAbilityTypeCommandRequest request, CancellationToken cancellationToken)
    {
        // Ensure that the specified AbilityType ID exists before attempting to change its status
        await _abilityTypeBusinessRules.IdShouldBeExist(request.ChangeStatusAbilityTypeDto.Id);

        // Retrieve the AbilityType with the specified ID using AbilityTypeService
        AbilityType abilityType = await _abilityTypeService.GetById(request.ChangeStatusAbilityTypeDto.Id);

        // Toggle the status of the AbilityType (switch between true and false)
        abilityType.Status = abilityType.Status == true ? false : true;

        // Set the updated date of the AbilityType to the current date and time
        abilityType.UpdatedDate = DateTime.Now;

        // Update the AbilityType by calling the _abilityTypeService
        await _abilityTypeService.Update(abilityType);

        // Map the updated AbilityType to the response DTO
        ChangeStatusAbilityTypeCommandResponse mappedResponse = _mapper.Map<ChangeStatusAbilityTypeCommandResponse>(abilityType);

        // Return the mapped response to the calling code
        return mappedResponse;

    }
}
