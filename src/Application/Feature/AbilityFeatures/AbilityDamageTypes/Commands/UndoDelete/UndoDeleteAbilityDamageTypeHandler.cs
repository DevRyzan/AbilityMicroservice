using Application.Feature.AbilityFeatures.AbilityDamageTypes.Rules;
using Application.Service.AbilityServices.AbilityDamageTypeService;
using AutoMapper;
using Domain.Abilities;
using MediatR;


namespace Application.Feature.AbilityFeatures.AbilityDamageTypes.Commands.UndoDelete;

public class UndoDeleteAbilityDamageTypeHandler : IRequestHandler<UndoDeleteAbilityDamageTypeRequest, UndoDeleteAbilityDamageTypeResponse>
{
    private readonly IAbilityDamageTypeService _abilityDamageTypeService;
    private readonly AbilityDamageTypeBusinessRules _abilityDamageTypeBusinessRules;
    private readonly IMapper _mapper;

    public UndoDeleteAbilityDamageTypeHandler(IAbilityDamageTypeService abilityDamageTypeService, AbilityDamageTypeBusinessRules abilityDamageTypeBusinessRules, IMapper mapper)
    {
        _abilityDamageTypeService = abilityDamageTypeService;
        _abilityDamageTypeBusinessRules = abilityDamageTypeBusinessRules;
        _mapper = mapper;
    }

    public async Task<UndoDeleteAbilityDamageTypeResponse> Handle(UndoDeleteAbilityDamageTypeRequest request, CancellationToken cancellationToken)
    {
        // Check the existence of the specified ID; it should comply with business rules.
        await _abilityDamageTypeBusinessRules.IdShouldBeExist(request.UndoDeleteAbilityDamageTypeDto.Id);

        // Retrieve the AbilityDamageType associated with the provided ID from the service.
        AbilityDamageType abilityDamageType = await _abilityDamageTypeService.GetById(request.UndoDeleteAbilityDamageTypeDto.Id);

        // Set the 'IsDeleted' flag to false, indicating the undo of the deletion.
        abilityDamageType.IsDeleted = false;

        // Update the 'UpdatedDate' property to the current date and time.
        abilityDamageType.UpdatedDate = DateTime.Now;

        // Update the AbilityDamageType in the database.
        await _abilityDamageTypeService.Update(abilityDamageType);

        // Map the updated AbilityDamageType to the response DTO.
        UndoDeleteAbilityDamageTypeResponse mappedResponse = _mapper.Map<UndoDeleteAbilityDamageTypeResponse>(abilityDamageType);

        // Return the mapped response.
        return mappedResponse;
    }
}
