using Application.Feature.AbilityFeatures.AbilityEffectDisableTypes.Rules;
using Application.Service.AbilityServices.AbilityEffectDisableTypeService;
using AutoMapper;
using Domain.Abilities;
using MediatR;



namespace Application.Feature.AbilityFeatures.AbilityEffectDisableTypes.Commands.Remove;

public class RemoveAbilityEffectDisableTypeHandler : IRequestHandler<RemoveAbilityEffectDisableTypeRequest, RemoveAbilityEffectDisableTypeResponse>
{
    private readonly IAbilityEffectDisableTypeService _abilityEffectDisableTypeService;
    private readonly AbilityEffectDisableTypeBusinessRules _abilityEffectDisableTypeBusinessRules;
    private readonly IMapper _mapper;

    public RemoveAbilityEffectDisableTypeHandler(IAbilityEffectDisableTypeService abilityEffectDisableTypeService, AbilityEffectDisableTypeBusinessRules abilityEffectDisableTypeBusinessRules, IMapper mapper)
    {
        _abilityEffectDisableTypeService = abilityEffectDisableTypeService;
        _abilityEffectDisableTypeBusinessRules = abilityEffectDisableTypeBusinessRules;
        _mapper = mapper;
    }

    public async Task<RemoveAbilityEffectDisableTypeResponse> Handle(RemoveAbilityEffectDisableTypeRequest request, CancellationToken cancellationToken)
    {
        // Check the existence of the specified ID; it should comply with business rules.
        await _abilityEffectDisableTypeBusinessRules.IdShouldBeExist(request.RemoveAbilityEffectDisableTypeDto.Id);

        // Remove any additional conditions related to the specified ID; complying with business rules.
        await _abilityEffectDisableTypeBusinessRules.RemoveCondition(request.RemoveAbilityEffectDisableTypeDto.Id);

        // Retrieve the AbilityEffectDisableType associated with the provided ID from the service.
        AbilityEffectDisableType abilityEffectDisableType = await _abilityEffectDisableTypeService.GetById(request.RemoveAbilityEffectDisableTypeDto.Id);

        // Remove the AbilityEffectDisableType from the database.
        await _abilityEffectDisableTypeService.Remove(abilityEffectDisableType);

        // Map the removed AbilityEffectDisableType to the response DTO.
        RemoveAbilityEffectDisableTypeResponse mappedResponse = _mapper.Map<RemoveAbilityEffectDisableTypeResponse>(abilityEffectDisableType);

        // Return the mapped response.
        return mappedResponse;

    }
}
