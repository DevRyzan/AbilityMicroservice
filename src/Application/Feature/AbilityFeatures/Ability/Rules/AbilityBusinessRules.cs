using Application.Feature.AbilityFeatures.Ability.Constants;
using Application.Service.Repositories;
using Core.Application;
using Core.CrossCuttingConcerns.Exceptions;
using MongoDB.Bson;

namespace Application.Feature.AbilityFeatures.Ability.Rules;

public class AbilityBusinessRules: BaseBusinessRules
{
    private readonly IAbilityRepository _abilityRepository;

    public AbilityBusinessRules(IAbilityRepository abilityRepository)
    {
        _abilityRepository = abilityRepository;
    }

    public AbilityBusinessRules()
    {
        
    }

    public virtual async Task IdShouldBeExist(string id)
    {
        var ability = await _abilityRepository.GetAsync(x => x.Id.Equals(id));
        if (ability == null) throw new BusinessException(AbilityMessages.AbilityIdDontExist);
    }

    public virtual async Task PageRequestShouldBeValid(int index, int size)
    {
        if (index < 0 || size <= 0) throw new BusinessException(AbilityMessages.PageRequestShouldBeValid);
    }
    public virtual async Task RemoveCondition(string id)
    {
        Domain.Abilities.Ability ability = await _abilityRepository.GetAsync(x => x.Id.Equals(id));
        if (ability.Status == true || ability.IsDeleted == false) throw new BusinessException(AbilityMessages.RemoveCondition);
    }
}
