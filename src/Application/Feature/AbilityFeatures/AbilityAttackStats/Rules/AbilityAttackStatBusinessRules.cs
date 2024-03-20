using Application.Feature.AbilityFeatures.AbilityAttackStats.Constants;
using Application.Service.Repositories;
using Core.Application;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Abilities;


namespace Application.Feature.AbilityFeatures.AbilityAttackStats.Rules;

public class AbilityAttackStatBusinessRules : BaseBusinessRules
{
    private readonly IAbilityAttackStatRepository _abilityAttackStatRepository;

    public AbilityAttackStatBusinessRules(IAbilityAttackStatRepository abilityAttackStatRepository)
    {
        _abilityAttackStatRepository = abilityAttackStatRepository;
    }
    public AbilityAttackStatBusinessRules()
    {
        
    }

    public async Task PageRequestShouldBeValid(int index, int size)
    {
        if (index < 0 || size <= 0) throw new BusinessException(AbilityAttackStatMessages.PageRequestShouldBeValid);
    }

    public virtual async Task IdShouldBeExist(string id)
    {
        AbilityAttackStat abilityAttackStat = await _abilityAttackStatRepository.GetAsync(x => x.Id.Equals(id));
        if (abilityAttackStat == null) throw new BusinessException(AbilityAttackStatMessages.IdShouldBeExist);
    }
    public virtual async Task RemoveCondition(string id)
    {
        AbilityAttackStat abilityAttackStat = await _abilityAttackStatRepository.GetAsync(x => x.Id.Equals(id));
        if (abilityAttackStat.Status == true || abilityAttackStat.IsDeleted == false) throw new BusinessException(AbilityAttackStatMessages.RemoveCondition);
    }
}
