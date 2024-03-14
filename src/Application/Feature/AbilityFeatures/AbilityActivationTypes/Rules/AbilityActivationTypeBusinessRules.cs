using Application.Feature.AbilityFeatures.AbilityActivationTypes.Constants;
using Application.Service.Repositories;
using Core.Application;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Abilities;


namespace Application.Feature.AbilityFeatures.AbilityActivationTypes.Rules;

public class AbilityActivationTypeBusinessRules : BaseBusinessRules
{
    private readonly IAbilityActivationTypeRepository _abilityActivationTypeRepository;

    public AbilityActivationTypeBusinessRules(IAbilityActivationTypeRepository abilityActivationTypeRepository)
    {
        _abilityActivationTypeRepository = abilityActivationTypeRepository;
    }

    public AbilityActivationTypeBusinessRules()
    {
        
    }

    public async Task PageRequestShouldBeValid(int index, int size)
    {
        if (index < 0 || size <= 0) throw new BusinessException(AbilityActivationTypeMessages.PageRequestShouldBeValid);
    }

    public virtual async Task IdShouldBeExist(string id)
    {
        AbilityActivationType abilityActivationType = await _abilityActivationTypeRepository.GetAsync(x => x.Id.Equals(id));
        if (abilityActivationType == null) throw new BusinessException(AbilityActivationTypeMessages.IdShouldBeExist);
    }
    public virtual async Task RemoveCondition(string id)
    {
        AbilityActivationType abilityActivationType = await _abilityActivationTypeRepository.GetAsync(x => x.Id.Equals(id));
        if (abilityActivationType.Status == true || abilityActivationType.IsDeleted == false) throw new BusinessException(AbilityActivationTypeMessages.RemoveCondition);
    }
}
