using Application.Feature.AbilityFeatures.AbilityEffects.Constants;
using Application.Service.Repositories;
using Core.Application;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Abilities;


namespace Application.Feature.AbilityFeatures.AbilityEffects.Rules;

public class AbilityEffectBusinessRules : BaseBusinessRules
{
    private readonly IAbilityEffectRepository _abilityEffectRepository;

    public AbilityEffectBusinessRules(IAbilityEffectRepository abilityEffectRepository)
    {
        _abilityEffectRepository = abilityEffectRepository;
    }

    public async Task PageRequestShouldBeValid(int index, int size)
    {
        if (index < 0 || size <= 0) throw new BusinessException(AbilityEffectMessages.PageRequestShouldBeValid);
    }
    public async Task IdShouldBeExist(string id)
    {
        AbilityEffect abilityEffect= await _abilityEffectRepository.GetAsync(x => x.Id.Equals(id));
        if (abilityEffect == null) throw new BusinessException(AbilityEffectMessages.IdShouldBeExist);
    }

    public async Task RemoveCondition(string id)
    {
        AbilityEffect abilityEffect = await _abilityEffectRepository.GetAsync(x => x.Id.Equals(id));
        if (abilityEffect.Status == true || abilityEffect.IsDeleted == false) throw new BusinessException(AbilityEffectMessages.RemoveCondition);
    }
}
