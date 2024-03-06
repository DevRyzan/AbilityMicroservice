using Application.Feature.AbilityFeatures.AbilityTypes.Constants;
using Application.Service.Repositories;
using Core.Application;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Abilities;


namespace Application.Feature.AbilityFeatures.AbilityTypes.Rules;

public class AbilityTypeBusinessRules : BaseBusinessRules
{
    public AbilityTypeBusinessRules()
    {
        
    }
    private readonly IAbilityTypeRepository _abilityTypeRepository;

    public AbilityTypeBusinessRules(IAbilityTypeRepository abilityTypeRepository)
    {
        _abilityTypeRepository = abilityTypeRepository;
    }

    public async Task PageRequestShouldBeValid(int index, int size)
    {
        if (index < 0 || size <= 0) throw new BusinessException(AbilityTypeMessages.PageRequestShouldBeValid);
    }
    public virtual async Task IdShouldBeExist(string id)
    {
        AbilityType abilityType = await _abilityTypeRepository.GetAsync(x => x.Id.Equals(id));
        if (abilityType == null) throw new BusinessException(AbilityTypeMessages.IdShouldBeExist);
    }

    public virtual async Task RemoveCondition(string id)
    {
        AbilityType abilityType = await _abilityTypeRepository.GetAsync(x => x.Id.Equals(id));
        if (abilityType.Status == true || abilityType.IsDeleted == false) throw new BusinessException(AbilityTypeMessages.RemoveCondition);
    }


}
