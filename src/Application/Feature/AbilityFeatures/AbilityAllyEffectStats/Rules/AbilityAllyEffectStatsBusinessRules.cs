using Application.Feature.AbilityFeatures.AbilityAffectUnits.Constants;
using Application.Service.Repositories;
using Core.Application;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Abilities;


namespace Application.Feature.AbilityFeatures.AbilityAllyEffectStats.Rules;

public class AbilityAllyEffectStatsBusinessRules : BaseBusinessRules
{
    private readonly IAbilityAllyEffectStatRepository _abilityAllyEffectStatRepository;

    public AbilityAllyEffectStatsBusinessRules(IAbilityAllyEffectStatRepository abilityAllyEffectStatRepository)
    {
        _abilityAllyEffectStatRepository = abilityAllyEffectStatRepository;
    }

    public async Task PageRequestShouldBeValid(int index, int size)
    {
        if (index < 0 || size <= 0) throw new BusinessException(AbilityAffectUnitMessages.PageRequestShouldBeValid);
    }

    public async Task IdShouldBeExist(string id)
    {
        AbilityAllyEffectStat abilityAllyEffectStat = await _abilityAllyEffectStatRepository.GetAsync(x => x.Id.Equals(id));
        if (abilityAllyEffectStat == null) throw new BusinessException(AbilityAffectUnitMessages.IdShouldBeExist);
    }
    public async Task RemoveCondition(string id)
    {
        AbilityAllyEffectStat abilityAllyEffectStat = await _abilityAllyEffectStatRepository.GetAsync(x => x.Id.Equals(id));
        if (abilityAllyEffectStat.Status == true || abilityAllyEffectStat.IsDeleted == false) throw new BusinessException(AbilityAffectUnitMessages.RemoveCondition);
    }

}
