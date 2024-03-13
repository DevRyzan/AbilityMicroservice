using Application.Feature.AbilityFeatures.AbilityEffectTypes.Rules;
using Application.Service.AbilityServices.AbilityEffectTypeService;
using AutoMapper;
using Domain.Abilities;
using MediatR;



namespace Application.Feature.AbilityFeatures.AbilityEffectTypes.Commands.UndoDelete;

public class UndoDeleteAbilityEffectTypeHandler : IRequestHandler<UndoDeleteAbilityEffectTypeRequest, UndoDeleteAbilityEffectTypeResponse>
{
    private readonly IAbilityEffectTypeService _abilityTypeService;
    private readonly AbilityEffectTypeBusinessRules _abilityEffectTypeBusinessRules;
    private readonly IMapper _mapper;

    public UndoDeleteAbilityEffectTypeHandler(IAbilityEffectTypeService abilityTypeService, AbilityEffectTypeBusinessRules abilityEffectTypeBusinessRules, IMapper mapper)
    {
        _abilityTypeService = abilityTypeService;
        _abilityEffectTypeBusinessRules = abilityEffectTypeBusinessRules;
        _mapper = mapper;
    }

    public async Task<UndoDeleteAbilityEffectTypeResponse> Handle(UndoDeleteAbilityEffectTypeRequest request, CancellationToken cancellationToken)
    {
        // Ensure that the provided ID exists in the business rules before undoing the delete operation
        await _abilityEffectTypeBusinessRules.IdShouldBeExist(request.UndoDeleteAbilityEffectTypeDto.Id);

        // Retrieve the AbilityEffectType from the service using the provided ID
        AbilityEffectType abilityEffectType = await _abilityTypeService.GetById(request.UndoDeleteAbilityEffectTypeDto.Id);

        // Undo the delete operation by marking IsDeleted as false and updating the UpdatedDate
        abilityEffectType.IsDeleted = false;
        abilityEffectType.UpdatedDate = DateTime.Now;

        // Update the AbilityEffectType in the service to persist the changes
        await _abilityTypeService.Update(abilityEffectType);

        // Map the undone AbilityEffectType to the response DTO
        UndoDeleteAbilityEffectTypeResponse mappedResponse = _mapper.Map<UndoDeleteAbilityEffectTypeResponse>(abilityEffectType);

        // Return the mapped response
        return mappedResponse;

    }
}
