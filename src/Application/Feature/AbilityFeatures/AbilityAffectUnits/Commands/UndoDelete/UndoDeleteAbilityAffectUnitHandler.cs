using Application.Feature.AbilityFeatures.AbilityAffectUnits.Rules;
using Application.Service.AbilityServices.AbilityAffectUnitService;
using AutoMapper;
using Domain.Abilities;
using MediatR;


namespace Application.Feature.AbilityFeatures.AbilityAffectUnits.Commands.UndoDelete;

public class UndoDeleteAbilityAffectUnitHandler : IRequestHandler<UndoDeleteAbilityAffectUnitRequest, UndoDeleteAbilityAffectUnitResponse>
{
    private readonly IAbilityAffectUnitService _abilityAffectUnitService;
    private readonly AbilityAffectUnitBusinessRules _abilityAffectUnitBusinessRules;
    private readonly IMapper _mapper;

    public UndoDeleteAbilityAffectUnitHandler(IAbilityAffectUnitService abilityAffectUnitService, AbilityAffectUnitBusinessRules abilityAffectUnitBusinessRules, IMapper mapper)
    {
        _abilityAffectUnitService = abilityAffectUnitService;
        _abilityAffectUnitBusinessRules = abilityAffectUnitBusinessRules;
        _mapper = mapper;
    }

    public async Task<UndoDeleteAbilityAffectUnitResponse> Handle(UndoDeleteAbilityAffectUnitRequest request, CancellationToken cancellationToken)
    {
        // Check the existence of the specified ID; it should comply with business rules.
        await _abilityAffectUnitBusinessRules.IdShouldBeExist(request.UndoDeleteAbilityAffectUnitDto.Id);

        // Retrieve the AbilityAffectUnit associated with the provided ID from the service.
        AbilityAffectUnit abilityAffectUnit = await _abilityAffectUnitService.GetById(request.UndoDeleteAbilityAffectUnitDto.Id);

        // Set the 'IsDeleted' flag to false, indicating the undo of the deletion.
        abilityAffectUnit.IsDeleted = false;

        // Update the 'UpdatedDate' property to the current date and time.
        abilityAffectUnit.UpdatedDate = DateTime.Now;

        // Update the AbilityAffectUnit in the database.
        await _abilityAffectUnitService.Update(abilityAffectUnit);

        // Map the updated AbilityAffectUnit to the response DTO.
        UndoDeleteAbilityAffectUnitResponse mappedResponse = _mapper.Map<UndoDeleteAbilityAffectUnitResponse>(abilityAffectUnit);

        // Return the mapped response.
        return mappedResponse;

    }
}
