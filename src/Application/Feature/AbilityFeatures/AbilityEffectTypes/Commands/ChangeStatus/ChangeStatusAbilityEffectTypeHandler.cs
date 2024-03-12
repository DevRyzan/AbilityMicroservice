using Application.Feature.AbilityFeatures.AbilityEffectTypes.Rules;
using Application.Service.AbilityServices.AbilityEffectTypeService;
using AutoMapper;
using Domain.Abilities;
using MediatR;


namespace Application.Feature.AbilityFeatures.AbilityEffectTypes.Commands.ChangeStatus;

public class ChangeStatusAbilityEffectTypeHandler : IRequestHandler<ChangeStatusAbilityEffectTypeRequest, ChangeStatusAbilityEffectTypeResponse>
{
    private readonly IAbilityEffectTypeService _abilityEffectTypeService;
    private readonly AbilityEffectTypeBusinessRules _abilityEffectTypeBusinessRules;
    private readonly IMapper _mapper;

    public ChangeStatusAbilityEffectTypeHandler(IAbilityEffectTypeService abilityEffectTypeService, AbilityEffectTypeBusinessRules abilityEffectTypeBusinessRules, IMapper mapper)
    {
        _abilityEffectTypeService = abilityEffectTypeService;
        _abilityEffectTypeBusinessRules = abilityEffectTypeBusinessRules;
        _mapper = mapper;
    }

    public async Task<ChangeStatusAbilityEffectTypeResponse> Handle(ChangeStatusAbilityEffectTypeRequest request, CancellationToken cancellationToken)
    {
        // Check if the provided ID exists for AbilityEffectType using business rules
        await _abilityEffectTypeBusinessRules.IdShouldBeExist(request.ChangeStatusAbilityEffectTypeDto.Id);

        // Retrieve the AbilityEffectType from the service using the provided ID
        AbilityEffectType abilityEffectType = await _abilityEffectTypeService.GetById(request.ChangeStatusAbilityEffectTypeDto.Id);

        // Toggle the status of the AbilityEffectType (if it's true, set to false, and vice versa)
        abilityEffectType.Status = abilityEffectType.Status == true ? false : true;

        // Update the UpdatedDate to the current timestamp
        abilityEffectType.UpdatedDate = DateTime.Now;

        // Update the AbilityEffectType in the database using the service
        await _abilityEffectTypeService.Update(abilityEffectType);

        // Map the updated AbilityEffectType to the response DTO
        ChangeStatusAbilityEffectTypeResponse mappedResponse = _mapper.Map<ChangeStatusAbilityEffectTypeResponse>(abilityEffectType);

        // Return the mapped response
        return mappedResponse;

    }
}
