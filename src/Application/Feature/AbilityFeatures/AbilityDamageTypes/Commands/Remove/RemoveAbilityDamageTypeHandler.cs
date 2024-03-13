using Application.Feature.AbilityFeatures.AbilityDamageTypes.Rules;
using Application.Service.AbilityServices.AbilityDamageTypeService;
using AutoMapper;
using Domain.Abilities;
using MediatR;


namespace Application.Feature.AbilityFeatures.AbilityDamageTypes.Commands.Remove;

public class RemoveAbilityDamageTypeHandler : IRequestHandler<RemoveAbilityDamageTypeRequest, RemoveAbilityDamageTypeResponse>
{
    private readonly IAbilityDamageTypeService _abilityDamageTypeService;
    private readonly AbilityDamageTypeBusinessRules _abilityDamageTypeBusinessRules;
    private readonly IMapper _mapper;

    public RemoveAbilityDamageTypeHandler(IAbilityDamageTypeService abilityDamageTypeService, AbilityDamageTypeBusinessRules abilityDamageTypeBusinessRules, IMapper mapper)
    {
        _abilityDamageTypeService = abilityDamageTypeService;
        _abilityDamageTypeBusinessRules = abilityDamageTypeBusinessRules;
        _mapper = mapper;
    }

    public async Task<RemoveAbilityDamageTypeResponse> Handle(RemoveAbilityDamageTypeRequest request, CancellationToken cancellationToken)
    {
        // Check the existence of the specified ID; it should comply with business rules.
        await _abilityDamageTypeBusinessRules.IdShouldBeExist(request.RemoveAbilityDamageTypeDto.Id);

        // Check additional conditions for the removal process.
        await _abilityDamageTypeBusinessRules.RemoveCondition(request.RemoveAbilityDamageTypeDto.Id);

        // Retrieve the AbilityDamageType associated with the provided ID from the service.
        AbilityDamageType abilityDamageType = await _abilityDamageTypeService.GetById(request.RemoveAbilityDamageTypeDto.Id);

        // Remove the AbilityDamageType from the database using the service.
        await _abilityDamageTypeService.Remove(abilityDamageType);

        // Map the removed AbilityDamageType to the response DTO.
        RemoveAbilityDamageTypeResponse mappedResponse = _mapper.Map<RemoveAbilityDamageTypeResponse>(abilityDamageType);

        // Return the mapped response.
        return mappedResponse;

    }
}
