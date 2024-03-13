using Application.Feature.AbilityFeatures.AbilityEffectTypes.Rules;
using Application.Service.AbilityServices.AbilityEffectTypeService;
using AutoMapper;
using Domain.Abilities;
using MediatR;


namespace Application.Feature.AbilityFeatures.AbilityEffectTypes.Commands.Remove;

public class RemoveAbilityEffectTypeHandler : IRequestHandler<RemoveAbilityEffectTypeRequest, RemoveAbilityEffectTypeResponse>
{
    private readonly IAbilityEffectTypeService _abilityTypeService;
    private readonly AbilityEffectTypeBusinessRules _abilityEffectTypeBusinessRules;
    private readonly IMapper _mapper;

    public RemoveAbilityEffectTypeHandler(IAbilityEffectTypeService abilityTypeService, AbilityEffectTypeBusinessRules abilityEffectTypeBusinessRules, IMapper mapper)
    {
        _abilityTypeService = abilityTypeService;
        _abilityEffectTypeBusinessRules = abilityEffectTypeBusinessRules;
        _mapper = mapper;
    }

    public async Task<RemoveAbilityEffectTypeResponse> Handle(RemoveAbilityEffectTypeRequest request, CancellationToken cancellationToken)
    {
        // Ensure that the provided ID exists in the business rules before removal
        await _abilityEffectTypeBusinessRules.IdShouldBeExist(request.RemoveAbilityEffectTypeDto.Id);

        // Apply any additional removal conditions specified in the business rules
        await _abilityEffectTypeBusinessRules.RemoveCondition(id: request.RemoveAbilityEffectTypeDto.Id);

        // Retrieve the AbilityEffectType from the service using the provided ID
        AbilityEffectType abilityEffectType = await _abilityTypeService.GetById(request.RemoveAbilityEffectTypeDto.Id);

        // Use the service to remove the AbilityEffectType from the database
        await _abilityTypeService.Remove(abilityEffectType);

        // Map the removed AbilityEffectType to the response DTO
        RemoveAbilityEffectTypeResponse mappedResponse = _mapper.Map<RemoveAbilityEffectTypeResponse>(abilityEffectType);

        // Return the mapped response
        return mappedResponse;
    }
}
