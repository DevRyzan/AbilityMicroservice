using Application.Feature.AbilityFeatures.Ability.Constants;
using Application.Service.Repositories;
using Core.Application;
using Core.CrossCuttingConcerns.Exceptions;

namespace Application.Feature.AbilityFeatures.Ability.Rules;

public class AbilityBusinessRules: BaseBusinessRules
{
    private readonly IAbilityRepository _abilityRepository;

    public AbilityBusinessRules(IAbilityRepository abilityRepository)
    {
        _abilityRepository = abilityRepository;
    }

    public async Task AbilityIdShouldBeExist(Guid id)
    {
        var ability = await _abilityRepository.GetAsync(x => x.Id.Equals(id));
        if (ability == null) throw new BusinessException(AbilityMessages.AbilityIdDontExist);
    }
}
