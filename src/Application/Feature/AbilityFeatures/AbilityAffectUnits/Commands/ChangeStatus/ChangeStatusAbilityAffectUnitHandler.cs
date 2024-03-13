using Application.Feature.AbilityFeatures.AbilityAffectUnits.Rules;
using Application.Service.AbilityServices.AbilityAffectUnitService;
using AutoMapper;
using Domain.Abilities;
using MediatR;


namespace Application.Feature.AbilityFeatures.AbilityAffectUnits.Commands.ChangeStatus;

public class ChangeStatusAbilityAffectUnitHandler : IRequestHandler<ChangeStatusAbilityAffectUnitRequest, ChangeStatusAbilityAffectUnitResponse>
{
    private readonly IAbilityAffectUnitService _abilityAffectUnitService;
    private readonly AbilityAffectUnitBusinessRules _abilityAffectUnitBusinessRules;
    private readonly IMapper _mapper;

    public ChangeStatusAbilityAffectUnitHandler(IAbilityAffectUnitService abilityAffectUnitService, AbilityAffectUnitBusinessRules abilityAffectUnitBusinessRules, IMapper mapper)
    {
        _abilityAffectUnitService = abilityAffectUnitService;
        _abilityAffectUnitBusinessRules = abilityAffectUnitBusinessRules;
        _mapper = mapper;
    }

    public async Task<ChangeStatusAbilityAffectUnitResponse> Handle(ChangeStatusAbilityAffectUnitRequest request, CancellationToken cancellationToken)
    {
        // Check the existence of the specified ID; it should comply with business rules.
        await _abilityAffectUnitBusinessRules.IdShouldBeExist(request.ChangeStatusAbilityAffectUnitDto.Id);

        // Retrieve the AbilityAffectUnit associated with the provided ID from the service.
        AbilityAffectUnit abilityAffectUnit = await _abilityAffectUnitService.GetById(request.ChangeStatusAbilityAffectUnitDto.Id);

        // Toggle the status of the retrieved AbilityAffectUnit (switch between true and false).
        abilityAffectUnit.Status = abilityAffectUnit.Status == true ? false : true;

        // Update the 'UpdatedDate' property to the current date and time.
        abilityAffectUnit.UpdatedDate = DateTime.Now;

        // Update the AbilityAffectUnit in the database.
        await _abilityAffectUnitService.Update(abilityAffectUnit);

        // Map the updated AbilityAffectUnit to the response DTO.
        ChangeStatusAbilityAffectUnitResponse mappedResponse = _mapper.Map<ChangeStatusAbilityAffectUnitResponse>(abilityAffectUnit);

        // Return the mapped response.
        return mappedResponse;

    }
}
