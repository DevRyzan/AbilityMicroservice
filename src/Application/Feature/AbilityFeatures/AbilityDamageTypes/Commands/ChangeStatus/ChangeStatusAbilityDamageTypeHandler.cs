using Application.Feature.AbilityFeatures.AbilityDamageTypes.Rules;
using Application.Service.AbilityServices.AbilityDamageTypeService;
using AutoMapper;
using Domain.Abilities;
using MediatR;


namespace Application.Feature.AbilityFeatures.AbilityDamageTypes.Commands.ChangeStatus;

public class ChangeStatusAbilityDamageTypeHandler : IRequestHandler<ChangeStatusAbilityDamageTypeRequest, ChangeStatusAbilityDamageTypeResponse>
{
    private readonly IAbilityDamageTypeService _abilityDamageTypeService;
    private readonly AbilityDamageTypeBusinessRules _abilityDamageTypeBusinessRules;
    private readonly IMapper _mapper;

    public ChangeStatusAbilityDamageTypeHandler(IAbilityDamageTypeService abilityDamageTypeService, AbilityDamageTypeBusinessRules abilityDamageTypeBusinessRules, IMapper mapper)
    {
        _abilityDamageTypeService = abilityDamageTypeService;
        _abilityDamageTypeBusinessRules = abilityDamageTypeBusinessRules;
        _mapper = mapper;
    }

    public async Task<ChangeStatusAbilityDamageTypeResponse> Handle(ChangeStatusAbilityDamageTypeRequest request, CancellationToken cancellationToken)
    {
        // Check the existence of the specified ID; it should comply with business rules.
        await _abilityDamageTypeBusinessRules.IdShouldBeExist(request.ChangeStatusAbilityDamageTypeDto.Id);

        // Retrieve the AbilityDamageType associated with the provided ID from the service.
        AbilityDamageType abilityDamageType = await _abilityDamageTypeService.GetById(request.ChangeStatusAbilityDamageTypeDto.Id);

        // Toggle the status of the retrieved AbilityDamageType (switch between true and false).
        abilityDamageType.Status = abilityDamageType.Status == true ? false : true;

        // Update the 'UpdatedDate' property to the current date and time.
        abilityDamageType.UpdatedDate = DateTime.Now;

        // Update the AbilityDamageType in the database.
        await _abilityDamageTypeService.Update(abilityDamageType);

        // Map the updated AbilityDamageType to the response DTO.
        ChangeStatusAbilityDamageTypeResponse mappedResponse = _mapper.Map<ChangeStatusAbilityDamageTypeResponse>(abilityDamageType);

        // Return the mapped response.
        return mappedResponse;

    }
}
