using Application.Feature.AbilityFeatures.Ability.Constants;
using Application.Feature.AbilityFeatures.AbilityCategory.Constants;
using Application.Feature.AbilityFeatures.AbilityLevel.Constants;
using Application.Feature.AbilityFeatures.AbilityTargetType.Constants;
using Application.Service.Repositories;
using Core.Application;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Abilities;

namespace Application.Feature.AbilityFeatures.Ability.Rules;

public class AbilityBusinessRules: BaseBusinessRules
{
    private readonly IAbilityRepository _abilityRepository;

    public AbilityBusinessRules(IAbilityRepository abilityRepository)
    {
        _abilityRepository = abilityRepository;
    }

    public async Task IdShouldBeExist(Guid id)
    {
        var ability = await _abilityRepository.GetAsync(x => x.Id.Equals(id));
        if (ability == null) throw new BusinessException(AbilityMessages.AbilityIdDontExist);
    }

    public async Task PageRequestShouldBeValid(int index, int size)
    {
        if (index < 0 || size <= 0) throw new BusinessException(AbilityCategoryMessages.PageRequestShouldBeValid);
    }
    public async Task RemoveCondition(Guid id)
    {
        Domain.Abilities.Ability ability = await _abilityRepository.GetAsync(x => x.Id.Equals(id));
        if (ability.Status == true || ability.IsDeleted == false) throw new BusinessException(AbilityCategoryMessages.RemoveCondition);
    }
}
