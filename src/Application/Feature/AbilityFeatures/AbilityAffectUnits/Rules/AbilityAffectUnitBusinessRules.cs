using Application.Feature.AbilityFeatures.AbilityAffectUnits.Constants;
using Application.Service.Repositories;
using Core.Application;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Abilities;


namespace Application.Feature.AbilityFeatures.AbilityAffectUnits.Rules;

public class AbilityAffectUnitBusinessRules : BaseBusinessRules
{
    
    private readonly IAbilityAffectUnitRepository _abilityAffectUnitRepository;

    public AbilityAffectUnitBusinessRules(IAbilityAffectUnitRepository abilityAffectUnitRepository)
    {
        _abilityAffectUnitRepository = abilityAffectUnitRepository;
    }

    public async Task PageRequestShouldBeValid(int index, int size)
    {
        if (index < 0 || size <= 0) throw new BusinessException(AbilityAffectUnitMessages.PageRequestShouldBeValid);
    }

    public async Task IdShouldBeExist(string id)
    {
        AbilityAffectUnit abilityAffectUnit = await _abilityAffectUnitRepository.GetAsync(x => x.Id.Equals(id));
        if (abilityAffectUnit == null) throw new BusinessException(AbilityAffectUnitMessages.IdShouldBeExist);
    }
    public async Task RemoveCondition(string id)
    {
        AbilityAffectUnit abilityAffectUnit = await _abilityAffectUnitRepository.GetAsync(x => x.Id.Equals(id));
        if (abilityAffectUnit.Status == true || abilityAffectUnit.IsDeleted == false) throw new BusinessException(AbilityAffectUnitMessages.RemoveCondition);
    }
}
