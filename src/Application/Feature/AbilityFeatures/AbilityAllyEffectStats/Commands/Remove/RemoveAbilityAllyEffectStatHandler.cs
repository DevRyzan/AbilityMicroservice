using Application.Feature.AbilityFeatures.AbilityAllyEffectStats.Rules;
using Application.Service.AbilityServices.AbilityAllyEffectStatService;
using AutoMapper;
using Domain.Abilities;
using MediatR;


namespace Application.Feature.AbilityFeatures.AbilityAllyEffectStats.Commands.Remove;

public class RemoveAbilityAllyEffectStatHandler : IRequestHandler<RemoveAbilityAllyEffectStatRequest, RemoveAbilityAllyEffectStatResponse>
{
    private readonly IAbilityAllyEffectStatService _abilityAllyEffectStatService;
    private readonly AbilityAllyEffectStatsBusinessRules _abilityAllyEffectStatsBusinessRules;
    private readonly IMapper _mapper;

    public RemoveAbilityAllyEffectStatHandler(IAbilityAllyEffectStatService abilityAllyEffectStatService, AbilityAllyEffectStatsBusinessRules abilityAllyEffectStatsBusinessRules, IMapper mapper)
    {
        _abilityAllyEffectStatService = abilityAllyEffectStatService;
        _abilityAllyEffectStatsBusinessRules = abilityAllyEffectStatsBusinessRules;
        _mapper = mapper;
    }

    public async Task<RemoveAbilityAllyEffectStatResponse> Handle(RemoveAbilityAllyEffectStatRequest request, CancellationToken cancellationToken)
    {
        // Check the existence of the specified ID; it should comply with business rules.
        await _abilityAllyEffectStatsBusinessRules.IdShouldBeExist(request.RemoveAbilityAllyEffectStatDto.Id);

        // Check additional conditions for the removal process.
        await _abilityAllyEffectStatsBusinessRules.RemoveCondition(request.RemoveAbilityAllyEffectStatDto.Id);

        // Retrieve the AbilityAllyEffectStat associated with the provided ID from the service.
        AbilityAllyEffectStat abilityAllyEffectStat = await _abilityAllyEffectStatService.GetById(request.RemoveAbilityAllyEffectStatDto.Id);

        // Remove the AbilityAllyEffectStat from the database using the service.
        await _abilityAllyEffectStatService.Remove(abilityAllyEffectStat);

        // Map the removed AbilityAllyEffectStat to the response DTO.
        RemoveAbilityAllyEffectStatResponse mappedResponse = _mapper.Map<RemoveAbilityAllyEffectStatResponse>(abilityAllyEffectStat);

        // Return the mapped response.
        return mappedResponse;

    }
}
