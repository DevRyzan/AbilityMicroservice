using Application.Feature.AbilityFeatures.AbilityEffectDisableTypes.Constants;
using Application.Service.Repositories;
using Core.Application;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Abilities;


namespace Application.Feature.AbilityFeatures.AbilityEffectDisableTypes.Rules;

public class AbilityEffectDisableTypeBusinessRules : BaseBusinessRules
{
    private readonly IAbilityEffectDisableTypeRepository _abilityEffectDisableTypeRepository;

    public AbilityEffectDisableTypeBusinessRules(IAbilityEffectDisableTypeRepository abilityEffectDisableTypeRepository)
    {
        _abilityEffectDisableTypeRepository = abilityEffectDisableTypeRepository;
    }
    public AbilityEffectDisableTypeBusinessRules()
    {
        
    }

    public async Task PageRequestShouldBeValid(int index, int size)
    {
        if (index < 0 || size <= 0) throw new BusinessException(AbilityEffectDisableTypeMessages.PageRequestShouldBeValid);
    }
    public virtual async Task IdShouldBeExist(string id)
    {
        AbilityEffectDisableType abilityEffectDisableType = await _abilityEffectDisableTypeRepository.GetAsync(x => x.Id.Equals(id));
        if (abilityEffectDisableType == null) throw new BusinessException(AbilityEffectDisableTypeMessages.IdShouldBeExist);
    }

    public virtual async Task RemoveCondition(string id)
    {
        AbilityEffectDisableType abilityEffectDisableType = await _abilityEffectDisableTypeRepository.GetAsync(x => x.Id.Equals(id));
        if (abilityEffectDisableType.Status == true || abilityEffectDisableType.IsDeleted == false) throw new BusinessException(AbilityEffectDisableTypeMessages.RemoveCondition);
    }
}
