using Application.Feature.AbilityFeatures.AbilityEffectStats.Constants;
using Application.Service.Repositories;
using Core.Application;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Abilities;


namespace Application.Feature.AbilityFeatures.AbilityEffectStats.Rules;

public class AbilityEffectStatBusinessRules : BaseBusinessRules
{
    private readonly IAbilityEffectStatRepository _abilityEffectStatRepository;

    public AbilityEffectStatBusinessRules(IAbilityEffectStatRepository abilityEffectStatRepository)
    {
        _abilityEffectStatRepository = abilityEffectStatRepository;
    }
    public AbilityEffectStatBusinessRules()
    {
        
    }

    public async Task PageRequestShouldBeValid(int index, int size)
    {
        if (index < 0 || size <= 0) throw new BusinessException(AbilityEffectStatMessages.PageRequestShouldBeValid);
    }
    public virtual async Task IdShouldBeExist(string id)
    {
        AbilityEffectStat abilityEffectStat = await _abilityEffectStatRepository.GetAsync(x => x.Id.Equals(id));
        if (abilityEffectStat == null) throw new BusinessException(AbilityEffectStatMessages.IdShouldBeExist);
    }

    public virtual async Task RemoveCondition(string id)
    {
        AbilityEffectStat abilityEffectStat = await _abilityEffectStatRepository.GetAsync(x => x.Id.Equals(id));
        if (abilityEffectStat.Status == true || abilityEffectStat.IsDeleted == false) throw new BusinessException(AbilityEffectStatMessages.RemoveCondition);
    }
}
