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
        await _abilityAllyEffectStatsBusinessRules.IdShouldBeExist(request.RemoveAbilityAllyEffectStatDto.Id);
        await _abilityAllyEffectStatsBusinessRules.RemoveCondition(request.RemoveAbilityAllyEffectStatDto.Id);

        AbilityAllyEffectStat abilityAllyEffectStat = await _abilityAllyEffectStatService.GetById(request.RemoveAbilityAllyEffectStatDto.Id);

        await _abilityAllyEffectStatService.Remove(abilityAllyEffectStat);

        RemoveAbilityAllyEffectStatResponse mappedResponse = _mapper.Map<RemoveAbilityAllyEffectStatResponse>(abilityAllyEffectStat);
        return mappedResponse;
    }
}
