﻿using Application.Feature.AbilityFeatures.AbilityLevel.Constants;
using Application.Service.Repositories;
using Core.Application;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Abilities;


namespace Application.Feature.AbilityFeatures.AbilityLevel.Rules;

public class AbilityLevelBusinessRules : BaseBusinessRules
{
    private readonly IAbilityLevelRepository _abilityLevelRepository;

    public AbilityLevelBusinessRules(IAbilityLevelRepository abilityLevelRepository)
    {
        _abilityLevelRepository = abilityLevelRepository;
    }

    public async Task PageRequestShouldBeValid(int index, int size)
    {
        if (index < 0 || size <= 0) throw new BusinessException(AbilityLevelMessages.PageRequestShouldBeValid);
    }
    public async Task IdShouldBeExist(string id)
    {
        Domain.Abilities.AbilityLevel abilityCategory = await _abilityLevelRepository.GetAsync(x => x.Id.Equals(id));
        if (abilityCategory == null) throw new BusinessException(AbilityLevelMessages.IdShouldBeExist);
    }
    public async Task RemoveCondition(string id)
    {
        Domain.Abilities.AbilityLevel abilityLevel = await _abilityLevelRepository.GetAsync(x => x.Id.Equals(id));
        if (abilityLevel.Status == true || abilityLevel.IsDeleted == false) throw new BusinessException(AbilityLevelMessages.RemoveCondition);
    }
}
