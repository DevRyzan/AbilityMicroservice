using Application.Feature.AbilityFeatures.AbilityCategory.Constants;
using Application.Service.Repositories;
using Core.Application;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Abilities;

namespace Application.Feature.AbilityFeatures.AbilityCategory.Rules;

public class AbilityCategoryBusinessRules : BaseBusinessRules
{
    private readonly IAbilityCategoryRepository _abilityCategoryRepository;
    private readonly IAbilityCategoryDetailEngRepository _abilityCategoryDetailEngRepository;

    public AbilityCategoryBusinessRules(IAbilityCategoryRepository abilityCategoryRepository, IAbilityCategoryDetailEngRepository abilityCategoryDetailEngRepository)
    {
        _abilityCategoryRepository = abilityCategoryRepository;
        _abilityCategoryDetailEngRepository = abilityCategoryDetailEngRepository;
    }

    public async Task PageRequestShouldBeValid(int index, int size)
    {
        if (index < 0 || size <= 0) throw new BusinessException(AbilityCategoryMessages.PageRequestShouldBeValid);
    }

    public async Task CategoryNameAlreadyExist(string categoryName)
    {
        Domain.Abilities.AbilityCategoryDetailEng abilityCategoryDetailEng = await _abilityCategoryDetailEngRepository.GetAsync(x => x.Name.Equals(categoryName));
        if (abilityCategoryDetailEng != null) throw new BusinessException(AbilityCategoryMessages.CategoryNameAlreadyExist);
    }

    public async Task IdShouldBeExist(Guid id)
    {
        Domain.Abilities.AbilityCategory abilityCategory = await _abilityCategoryRepository.GetAsync(x => x.Id.Equals(id));
        if (abilityCategory == null) throw new BusinessException(AbilityCategoryMessages.IdShouldBeExist);
    }
    public async Task RemoveCondition(Guid id)
    {
        Domain.Abilities.AbilityCategory abilityCategory = await _abilityCategoryRepository.GetAsync(x => x.Id.Equals(id));
        if (abilityCategory.Status == true || abilityCategory.IsDeleted == false) throw new BusinessException(AbilityCategoryMessages.RemoveCondition);
    }
}
