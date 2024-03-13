using Application.Feature.AbilityFeatures.AbilityEffectDisableTypes.Rules;
using Application.Service.AbilityServices.AbilityEffectDisableTypeService;
using AutoMapper;
using Domain.Abilities;
using MediatR;


namespace Application.Feature.AbilityFeatures.AbilityEffectDisableTypes.Commands.ChangeStatus;

public class ChangeStatusAbilityEffectDisableTypeHandler : IRequestHandler<ChangeStatusAbilityEffectDisableTypeRequest, ChangeStatusAbilityEffectDisableTypeResponse>
{
    private readonly IAbilityEffectDisableTypeService _abilityEffectDisableTypeService;
    private readonly AbilityEffectDisableTypeBusinessRules _abilityEffectDisableTypeBusinessRules;
    private readonly IMapper _mapper;

    public ChangeStatusAbilityEffectDisableTypeHandler(IAbilityEffectDisableTypeService abilityEffectDisableTypeService, AbilityEffectDisableTypeBusinessRules abilityEffectDisableTypeBusinessRules, IMapper mapper)
    {
        _abilityEffectDisableTypeService = abilityEffectDisableTypeService;
        _abilityEffectDisableTypeBusinessRules = abilityEffectDisableTypeBusinessRules;
        _mapper = mapper;
    }

    public async Task<ChangeStatusAbilityEffectDisableTypeResponse> Handle(ChangeStatusAbilityEffectDisableTypeRequest request, CancellationToken cancellationToken)
    {
        // Check the existence of the specified ID; it should comply with business rules.
        await _abilityEffectDisableTypeBusinessRules.IdShouldBeExist(request.ChangeStatusAbilityEffectDisableTypeDto.Id);

        // Retrieve the AbilityEffectDisableType associated with the provided ID from the service.
        AbilityEffectDisableType abilityEffectDisableType = await _abilityEffectDisableTypeService.GetById(request.ChangeStatusAbilityEffectDisableTypeDto.Id);

        // Toggle the 'Status' property, indicating an activation or deactivation.
        abilityEffectDisableType.Status = !abilityEffectDisableType.Status;

        // Update the 'UpdatedDate' property to the current date and time.
        abilityEffectDisableType.UpdatedDate = DateTime.Now;

        // Update the AbilityEffectDisableType in the database.
        await _abilityEffectDisableTypeService.Update(abilityEffectDisableType);

        // Map the updated AbilityEffectDisableType to the response DTO.
        ChangeStatusAbilityEffectDisableTypeResponse mappedResponse = _mapper.Map<ChangeStatusAbilityEffectDisableTypeResponse>(abilityEffectDisableType);

        // Return the mapped response.
        return mappedResponse;

    }
}
