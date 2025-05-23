﻿using Application.Feature.AbilityFeatures.AbilityCombo.Constants;
using Application.Service.Repositories;
using Core.Application;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Abilities;

namespace Application.Feature.AbilityFeatures.AbilityCombo.Rules;

public class AbilityComboBusinessRules : BaseBusinessRules
{

    private readonly IAbilityComboRepository _abilityComboRepository;

    public AbilityComboBusinessRules(IAbilityComboRepository abilityComboRepository)
    {
        _abilityComboRepository = abilityComboRepository;
    }
    public AbilityComboBusinessRules()
    {
        
    }

    public async Task PageRequestShouldBeValid(int index, int size)
    {
        if (index < 0 || size <= 0) throw new BusinessException(AbilityComboMessages.PageRequestShouldBeValid);
    }

    public virtual async Task IdShouldBeExist(string id)
    {
        Domain.Abilities.AbilityCombo abilityCombo = await _abilityComboRepository.GetAsync(x => x.Id.Equals(id));
        if (abilityCombo == null) throw new BusinessException(AbilityComboMessages.IdShouldBeExist);
    }
    public virtual async Task RemoveCondition(string id)
    {
        Domain.Abilities.AbilityCombo abilityCombo = await _abilityComboRepository.GetAsync(x => x.Id.Equals(id));
        if (abilityCombo.Status == true || abilityCombo.IsDeleted == false) throw new BusinessException(AbilityComboMessages.RemoveCondition);
    }
}
