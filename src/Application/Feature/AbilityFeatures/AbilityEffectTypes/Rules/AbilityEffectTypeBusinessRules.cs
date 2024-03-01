using Application.Feature.AbilityFeatures.AbilityEffectTypes.Constants;
using Application.Service.Repositories;
using Core.Application;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Abilities;


namespace Application.Feature.AbilityFeatures.AbilityEffectTypes.Rules;

public class AbilityEffectTypeBusinessRules : BaseBusinessRules
{
    private readonly IAbilityEffectTypeRepository _abilityEffectTypeRepository;

    public AbilityEffectTypeBusinessRules(IAbilityEffectTypeRepository abilityEffectTypeRepository)
    {
        _abilityEffectTypeRepository = abilityEffectTypeRepository;
    }

    public async Task PageRequestShouldBeValid(int index, int size)
    {
        if (index < 0 || size <= 0) throw new BusinessException(AbilityEffectTypeMessages.PageRequestShouldBeValid);
    }
    public async Task IdShouldBeExist(string id)
    {
        AbilityEffectType abilityEffectType = await _abilityEffectTypeRepository.GetAsync(x => x.Id.Equals(id));
        if (abilityEffectType == null) throw new BusinessException(AbilityEffectTypeMessages.IdShouldBeExist);
    }

    public async Task RemoveCondition(string id)
    {
        AbilityEffectType abilityEffectType = await _abilityEffectTypeRepository.GetAsync(x => x.Id.Equals(id));
        if (abilityEffectType.Status == true || abilityEffectType.IsDeleted == false) throw new BusinessException(AbilityEffectTypeMessages.RemoveCondition);
    }

}
