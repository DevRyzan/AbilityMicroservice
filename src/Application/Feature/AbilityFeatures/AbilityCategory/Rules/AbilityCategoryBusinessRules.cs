using Application.Feature.AbilityFeatures.AbilityCategory.Constants;
using Application.Service.Repositories;
using Core.Application;
using Core.CrossCuttingConcerns.Exceptions;

namespace Application.Feature.AbilityFeatures.AbilityCategory.Rules;

public class AbilityCategoryBusinessRules : BaseBusinessRules
{
    private readonly IAbilityCategoryRepository _abilityCategoryRepository;

    public AbilityCategoryBusinessRules(IAbilityCategoryRepository abilityCategoryRepository)
    {
        _abilityCategoryRepository = abilityCategoryRepository;
    }


    public async Task IdShouldBeExist(Guid id)
    {
        Domain.Abilities.AbilityCategory abilityCategory = await _abilityCategoryRepository.GetAsync(x => x.Id.Equals(id));
        if (abilityCategory == null) throw new BusinessException(AbilityCategoryMessages.IdShouldBeExist);
    }
    public async Task RemoveCondition(Guid id) 
    {
        Domain.Abilities.AbilityCategory abilityCategory = await _abilityCategoryRepository.GetAsync(x => x.Id.Equals(id));
        if (abilityCategory.Status == true && abilityCategory.IsDeleted == false) throw new BusinessException(AbilityCategoryMessages.RemoveCondition);
    }
}
