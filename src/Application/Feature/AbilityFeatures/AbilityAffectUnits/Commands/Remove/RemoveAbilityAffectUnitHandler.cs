using Application.Feature.AbilityFeatures.AbilityAffectUnits.Rules;
using Application.Service.AbilityServices.AbilityAffectUnitService;
using AutoMapper;
using Domain.Abilities;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityAffectUnits.Commands.Remove;

public class RemoveAbilityAffectUnitHandler : IRequestHandler<RemoveAbilityAffectUnitRequest, RemoveAbilityAffectUnitResponse>
{
    private readonly IAbilityAffectUnitService _abilityAffectUnitService;
    private readonly AbilityAffectUnitBusinessRules _abilityAffectUnitBusinessRules;
    private readonly IMapper _mapper;

    public RemoveAbilityAffectUnitHandler(IAbilityAffectUnitService abilityAffectUnitService, AbilityAffectUnitBusinessRules abilityAffectUnitBusinessRules, IMapper mapper)
    {
        _abilityAffectUnitService = abilityAffectUnitService;
        _abilityAffectUnitBusinessRules = abilityAffectUnitBusinessRules;
        _mapper = mapper;
    }

    public async Task<RemoveAbilityAffectUnitResponse> Handle(RemoveAbilityAffectUnitRequest request, CancellationToken cancellationToken)
    {
        // Check additional conditions for the removal process.
        await _abilityAffectUnitBusinessRules.RemoveCondition(id: request.RemoveAbilityAffectUnitDto.Id);

        // Check the existence of the specified ID; it should comply with business rules.
        await _abilityAffectUnitBusinessRules.IdShouldBeExist(request.RemoveAbilityAffectUnitDto.Id);

        // Retrieve the AbilityAffectUnit associated with the provided ID from the service.
        AbilityAffectUnit abilityAffectUnit = await _abilityAffectUnitService.GetById(request.RemoveAbilityAffectUnitDto.Id);

        // Remove the AbilityAffectUnit from the database using the service.
        await _abilityAffectUnitService.Remove(abilityAffectUnit);

        // Map the removed AbilityAffectUnit to the response DTO.
        RemoveAbilityAffectUnitResponse mappedResponse = _mapper.Map<RemoveAbilityAffectUnitResponse>(abilityAffectUnit);

        // Return the mapped response.
        return mappedResponse;

    }
}
