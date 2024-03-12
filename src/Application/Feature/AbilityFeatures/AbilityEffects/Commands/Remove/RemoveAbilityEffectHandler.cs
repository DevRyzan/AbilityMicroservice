using Application.Feature.AbilityFeatures.AbilityEffects.Rules;
using Application.Service.AbilityServices.AbilityEffectService;
using AutoMapper;
using Domain.Abilities;
using MediatR;


namespace Application.Feature.AbilityFeatures.AbilityEffects.Commands.Remove;

public class RemoveAbilityEffectHandler : IRequestHandler<RemoveAbilityEffectRequest, RemoveAbilityEffectResponse>
{
    private readonly IAbilityEffectService _abilityEffectService;
    private readonly AbilityEffectBusinessRules _abilityEffectBusinessRules;
    private readonly IMapper _mapper;

    public RemoveAbilityEffectHandler(IAbilityEffectService abilityEffectService, AbilityEffectBusinessRules abilityEffectBusinessRules, IMapper mapper)
    {
        _abilityEffectService = abilityEffectService;
        _abilityEffectBusinessRules = abilityEffectBusinessRules;
        _mapper = mapper;
    }

    public async Task<RemoveAbilityEffectResponse> Handle(RemoveAbilityEffectRequest request, CancellationToken cancellationToken)
    {
        // Ensure that the provided ID exists before proceeding.
        await _abilityEffectBusinessRules.IdShouldBeExist(request.RemoveAbilityEffectDto.Id);

        // Apply additional business rules or conditions before removal.
        await _abilityEffectBusinessRules.RemoveCondition(request.RemoveAbilityEffectDto.Id);

        // Retrieve the AbilityEffect entity by ID.
        AbilityEffect abilityEffect = await _abilityEffectService.GetById(request.RemoveAbilityEffectDto.Id);

        // Remove the AbilityEffect in the service.
        await _abilityEffectService.Remove(abilityEffect);

        // Map the removed AbilityEffect to the response DTO.
        RemoveAbilityEffectResponse mappedResponse = _mapper.Map<RemoveAbilityEffectResponse>(abilityEffect);

        // Return the mapped response.
        return mappedResponse;

    }
}
