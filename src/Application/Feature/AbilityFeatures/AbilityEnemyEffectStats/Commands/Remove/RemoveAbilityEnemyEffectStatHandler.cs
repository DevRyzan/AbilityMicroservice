using Application.Feature.AbilityFeatures.AbilityEnemyEffectStats.Rules;
using Application.Service.AbilityServices.AbilityEnemyEffectStatService;
using AutoMapper;
using Domain.Abilities;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityEnemyEffectStats.Commands.Remove;

public class RemoveAbilityEnemyEffectStatHandler : IRequestHandler<RemoveAbilityEnemyEffectStatRequest, RemoveAbilityEnemyEffectStatResponse>
{
    private readonly IAbilityEnemyEffectStatService _abilityEnemyEffectStatService;
    private readonly AbilityEnemyEffectStatBusinessRules _abilityEnemyEffectStatBusinessRules;
    private readonly IMapper _mapper;

    public RemoveAbilityEnemyEffectStatHandler(IAbilityEnemyEffectStatService abilityEnemyEffectStatService, AbilityEnemyEffectStatBusinessRules abilityEnemyEffectStatBusinessRules, IMapper mapper)
    {
        _abilityEnemyEffectStatService = abilityEnemyEffectStatService;
        _abilityEnemyEffectStatBusinessRules = abilityEnemyEffectStatBusinessRules;
        _mapper = mapper;
    }

    public async Task<RemoveAbilityEnemyEffectStatResponse> Handle(RemoveAbilityEnemyEffectStatRequest request, CancellationToken cancellationToken)
    {
        // Check if the specified ID exists before attempting to remove
        await _abilityEnemyEffectStatBusinessRules.IdShouldBeExist(request.RemoveAbilityEnemyEffectStatDto.Id);

        // Check additional conditions for removal
        await _abilityEnemyEffectStatBusinessRules.RemoveCondition(request.RemoveAbilityEnemyEffectStatDto.Id);

        // Retrieve the AbilityEnemyEffectStat using the specified ID
        AbilityEnemyEffectStat abilityEnemyEffectStat = await _abilityEnemyEffectStatService.GetById(request.RemoveAbilityEnemyEffectStatDto.Id);

        // Call the service to perform the remove operation
        await _abilityEnemyEffectStatService.Remove(abilityEnemyEffectStat);

        // Map the removed AbilityEnemyEffectStat to the response DTO
        RemoveAbilityEnemyEffectStatResponse mappedResponse = _mapper.Map<RemoveAbilityEnemyEffectStatResponse>(abilityEnemyEffectStat);

        // Return the mapped response
        return mappedResponse;

    }
}
