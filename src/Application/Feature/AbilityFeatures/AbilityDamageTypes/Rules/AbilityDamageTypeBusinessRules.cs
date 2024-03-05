using Application.Feature.AbilityFeatures.AbilityDamageTypes.Constants;
using Application.Service.Repositories;
using Core.Application;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Abilities;


namespace Application.Feature.AbilityFeatures.AbilityDamageTypes.Rules;

public class AbilityDamageTypeBusinessRules :  BaseBusinessRules
{
    private readonly IAbilityDamageTypeRepository _abilityDamageTypeRepository;

    public AbilityDamageTypeBusinessRules(IAbilityDamageTypeRepository abilityDamageTypeRepository)
    {
        _abilityDamageTypeRepository = abilityDamageTypeRepository;
    }

    public async Task PageRequestShouldBeValid(int index, int size)
    {
        if (index < 0 || size <= 0) throw new BusinessException(AbilityDamageTypeMessages.PageRequestShouldBeValid);
    }
    public async Task IdShouldBeExist(string id)
    {
        AbilityDamageType abilityDamageType = await _abilityDamageTypeRepository.GetAsync(x => x.Id.Equals(id));
        if (abilityDamageType == null) throw new BusinessException(AbilityDamageTypeMessages.IdShouldBeExist);
    }

    public async Task RemoveCondition(string id)
    {
        AbilityDamageType abilityDamageType = await _abilityDamageTypeRepository.GetAsync(x => x.Id.Equals(id));
        if (abilityDamageType.Status == true || abilityDamageType.IsDeleted == false) throw new BusinessException(AbilityDamageTypeMessages.RemoveCondition);
    }


}
