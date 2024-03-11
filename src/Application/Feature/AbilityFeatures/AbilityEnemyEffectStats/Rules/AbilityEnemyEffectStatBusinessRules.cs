using Application.Feature.AbilityFeatures.AbilityEnemyEffectStats.Constants;
using Application.Service.Repositories;
using Core.Application;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Abilities;


namespace Application.Feature.AbilityFeatures.AbilityEnemyEffectStats.Rules;

public class AbilityEnemyEffectStatBusinessRules : BaseBusinessRules
{
    private readonly IAbilityEnemyEffectStatRepository _abilityEnemyEffectStatRepository;

    public AbilityEnemyEffectStatBusinessRules(IAbilityEnemyEffectStatRepository abilityEnemyEffectStatRepository)
    {
        _abilityEnemyEffectStatRepository = abilityEnemyEffectStatRepository;
    }

    public async Task PageRequestShouldBeValid(int index, int size)
    {
        if (index < 0 || size <= 0) throw new BusinessException(AbilityEnemyEffectStatMessages.PageRequestShouldBeValid);
    }
    public async Task IdShouldBeExist(string id)
    {
        AbilityEnemyEffectStat abilityEnemyEffectStat = await _abilityEnemyEffectStatRepository.GetAsync(x => x.Id.Equals(id));
        if (abilityEnemyEffectStat == null) throw new BusinessException(AbilityEnemyEffectStatMessages.IdShouldBeExist);
    }

    public async Task RemoveCondition(string id)
    {
        AbilityEnemyEffectStat abilityEnemyEffectStat = await _abilityEnemyEffectStatRepository.GetAsync(x => x.Id.Equals(id));
        if (abilityEnemyEffectStat.Status == true || abilityEnemyEffectStat.IsDeleted == false) throw new BusinessException(AbilityEnemyEffectStatMessages.RemoveCondition);
    }
}
