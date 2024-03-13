using Application.Feature.AbilityFeatures.AbilityEffectDisableTypes.Rules;
using Application.Service.AbilityServices.AbilityEffectDisableTypeService;
using AutoMapper;
using Domain.Abilities;
using MediatR;


namespace Application.Feature.AbilityFeatures.AbilityEffectDisableTypes.Commands.UndoDelete;

public class UndoDeleteAbilityEffectDisableTypeHandler : IRequestHandler<UndoDeleteAbilityEffectDisableTypeRequest, UndoDeleteAbilityEffectDisableTypeResponse>
{
    private readonly IAbilityEffectDisableTypeService _abilityEffectDisableTypeService;
    private readonly AbilityEffectDisableTypeBusinessRules _abilityEffectDisableTypeBusinessRules;
    private readonly IMapper _mapper;

    public UndoDeleteAbilityEffectDisableTypeHandler(IAbilityEffectDisableTypeService abilityEffectDisableTypeService, AbilityEffectDisableTypeBusinessRules abilityEffectDisableTypeBusinessRules, IMapper mapper)
    {
        _abilityEffectDisableTypeService = abilityEffectDisableTypeService;
        _abilityEffectDisableTypeBusinessRules = abilityEffectDisableTypeBusinessRules;
        _mapper = mapper;
    }

    public async Task<UndoDeleteAbilityEffectDisableTypeResponse> Handle(UndoDeleteAbilityEffectDisableTypeRequest request, CancellationToken cancellationToken)
    {
        // Check the existence of the specified ID; it should comply with business rules.
        await _abilityEffectDisableTypeBusinessRules.IdShouldBeExist(request.UndoDeleteAbilityEffectDisableTypeDto.Id);

        // Retrieve the AbilityEffectDisableType associated with the provided ID from the service.
        AbilityEffectDisableType abilityEffectDisableType = await _abilityEffectDisableTypeService.GetById(request.UndoDeleteAbilityEffectDisableTypeDto.Id);

        // Set the 'IsDeleted' flag to false, indicating the undo of the deletion.
        abilityEffectDisableType.IsDeleted = false;

        // Set the 'UpdatedDate' property to the current date and time.
        abilityEffectDisableType.UpdatedDate = DateTime.Now;

        // Update the AbilityEffectDisableType in the database.
        await _abilityEffectDisableTypeService.Update(abilityEffectDisableType);

        // Map the updated AbilityEffectDisableType to the response DTO.
        UndoDeleteAbilityEffectDisableTypeResponse mappedResponse = _mapper.Map<UndoDeleteAbilityEffectDisableTypeResponse>(abilityEffectDisableType);

        // Return the mapped response.
        return mappedResponse;

    }
}
