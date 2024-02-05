using Application.Feature.AbilityFeatures.AbilityTargetType.Constants;
using Application.Service.Repositories;
using Core.Application;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Abilities;

namespace Application.Feature.AbilityFeatures.AbilityTargetType.Rules;

public class AbilityTargetTypeBusinessRules : BaseBusinessRules
{
    private readonly IAbilityTargetTypeRepository _abilityTargetTypeRepository;
    private readonly IAbilityRepository _abilityRepository;

    public AbilityTargetTypeBusinessRules(IAbilityTargetTypeRepository abilityTargetTypeRepository, IAbilityRepository abilityRepository)
    {
        _abilityTargetTypeRepository = abilityTargetTypeRepository;
        _abilityRepository = abilityRepository;
    }

    public async Task PageRequestShouldBeValid(int index, int size)
    {
        if (index < 0 || size <= 0) throw new BusinessException(AbilityTargetTypeMessages.PageRequestShouldBeValid);
    }
    public async Task IdShouldBeExist(Guid id)
    {
        Domain.Abilities.AbilityTargetType abilityTargetType = await _abilityTargetTypeRepository.GetAsync(x => x.Id.Equals(id));
        if (abilityTargetType == null) throw new BusinessException(AbilityTargetTypeMessages.IdShouldBeExist);
    }
    public async Task RemoveCondition(Guid id)
    {
        Domain.Abilities.AbilityTargetType abilityTargetType = await _abilityTargetTypeRepository.GetAsync(x => x.Id.Equals(id));
        if (abilityTargetType.Status == true || abilityTargetType.IsDeleted == false) throw new BusinessException(AbilityTargetTypeMessages.RemoveCondition);
    }
    public async Task AbilityShouldBeAvailableForCreate(Guid abilityId) 
    {
        Domain.Abilities.AbilityTargetType abilityTargetType = await _abilityTargetTypeRepository.GetAsync(x => x.AbilityId.Equals(abilityId));
        if (abilityTargetType != null) throw new BusinessException(AbilityTargetTypeMessages.AbilityShouldBeAvailableForCreate);
    }

    public async Task AbilityShouldBeAvailableForUpdate(Guid abilityId,Guid Id)
    {
        Domain.Abilities.AbilityTargetType abilityTargetType = await _abilityTargetTypeRepository.GetAsync(x => x.AbilityId.Equals(abilityId) && !x.Id.Equals(Id));
        if (abilityTargetType != null) throw new BusinessException(AbilityTargetTypeMessages.AbilityShouldBeAvailableForUpdate);
    }

    public async Task AbilityShouldBeExist(Guid abilityId)
    {
        Domain.Abilities.Ability ability = await _abilityRepository.GetAsync(x => x.Id.Equals(abilityId));
        if (ability == null) throw new BusinessException(AbilityTargetTypeMessages.AbilityShouldBeExist);
    }
}
