using Application.Feature.AbilityFeatures.AbilitySelfEffectStats.Constants;
using Application.Service.Repositories;
using Core.Application;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Abilities;


namespace Application.Feature.AbilityFeatures.AbilitySelfEffectStats.Rules;

public class AbilitySelfEffectStatBusinessRules : BaseBusinessRules
{
    private readonly IAbilitySelfEffectStatRepository _abilitySelfEffectStatRepository;

    public AbilitySelfEffectStatBusinessRules(IAbilitySelfEffectStatRepository abilitySelfEffectStatRepository)
    {
        _abilitySelfEffectStatRepository = abilitySelfEffectStatRepository;
    }

    public async Task PageRequestShouldBeValid(int index, int size)
    {
        if (index < 0 || size <= 0) throw new BusinessException(AbilitySelfEffectStatMessages.PageRequestShouldBeValid);
    }
    public async Task IdShouldBeExist(string id)
    {
        AbilitySelfEffectStat abilitySelfEffectStat = await _abilitySelfEffectStatRepository.GetAsync(x => x.Id.Equals(id));
        if (abilitySelfEffectStat == null) throw new BusinessException(AbilitySelfEffectStatMessages.IdShouldBeExist);
    }

    public async Task RemoveCondition(string id)
    {
        AbilitySelfEffectStat abilitySelfEffectStat = await _abilitySelfEffectStatRepository.GetAsync(x => x.Id.Equals(id));
        if (abilitySelfEffectStat.Status == true || abilitySelfEffectStat.IsDeleted == false) throw new BusinessException(AbilitySelfEffectStatMessages.RemoveCondition);
    }

}
