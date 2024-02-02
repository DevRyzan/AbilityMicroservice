using Application.Feature.AbilityFeatures.AbilityTargetType.Constants;
using Application.Feature.AbilityFeatures.AbilityTargetTypeDetailEng.Constants;
using Application.Service.Repositories;
using Core.Application;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Abilities;

namespace Application.Feature.AbilityFeatures.AbilityTargetTypeDetailEng.Rules;

public class AbilityTargetTypeDetailEngBusinessRules : BaseBusinessRules
{
    private readonly IAbilityTargetTypeDetailEngRepository _abilityTargetTypeDetailEngRepository;
    private readonly IAbilityTargetTypeRepository _abilityTargetTypeRepository;

    public AbilityTargetTypeDetailEngBusinessRules(IAbilityTargetTypeDetailEngRepository abilityTargetTypeDetailEngRepository, IAbilityTargetTypeRepository abilityTargetTypeRepository)
    {
        _abilityTargetTypeDetailEngRepository = abilityTargetTypeDetailEngRepository;
        _abilityTargetTypeRepository = abilityTargetTypeRepository;
    }

    public async Task PageRequestShouldBeValid(int index, int size)
    {
        if (index < 0 || size <= 0) throw new BusinessException(AbilityTargetTypeDetailEngMessages.PageRequestShouldBeValid);
    }
    public async Task IdShouldBeExist(Guid id)
    {
        Domain.Abilities.AbilityTargetTypeDetailEng abilityTargetTypeDetailEng = await _abilityTargetTypeDetailEngRepository.GetAsync(x => x.Id.Equals(id));
        if (abilityTargetTypeDetailEng == null) throw new BusinessException(AbilityTargetTypeDetailEngMessages.IdShouldBeExist);
    }
    public async Task RemoveCondition(Guid id)
    {
        Domain.Abilities.AbilityTargetTypeDetailEng abilityTargetTypeDetailEng = await _abilityTargetTypeDetailEngRepository.GetAsync(x => x.Id.Equals(id));
        if (abilityTargetTypeDetailEng.Status == true || abilityTargetTypeDetailEng.IsDeleted == false) throw new BusinessException(AbilityTargetTypeMessages.RemoveCondition);
    }
    public async Task AbilityTargetTypeShouldBeExist(Guid abilityTargetTypeId) 
    {
        Domain.Abilities.AbilityTargetType abilityTargetType = await _abilityTargetTypeRepository.GetAsync(x => x.Id.Equals(abilityTargetTypeId));
        if (abilityTargetType == null) throw new BusinessException(AbilityTargetTypeDetailEngMessages.AbilityTargetTypeShouldBeExist);
    }

    public async Task AbilityTargetTypeShouldBeAvailableForUpdate(Guid abilityTargetTypeId,Guid Id)
    {
        Domain.Abilities.AbilityTargetTypeDetailEng abilityTargetTypeDetailEng = await _abilityTargetTypeDetailEngRepository.GetAsync(x => x.AbilityTargetTypeId.Equals(abilityTargetTypeId) &&  !x.Id.Equals(Id));
        if (abilityTargetTypeDetailEng != null) throw new BusinessException(AbilityTargetTypeDetailEngMessages.AbilityTargetTypeShouldBeAvailableForUpdate);
    }

    public async Task AbilityTargetTypeShouldBeAvailableForCreate(Guid abilityTargetTypeId)
    {
        Domain.Abilities.AbilityTargetTypeDetailEng abilityTargetTypeDetailEng = await _abilityTargetTypeDetailEngRepository.GetAsync(x => x.AbilityTargetTypeId.Equals(abilityTargetTypeId));
        if (abilityTargetTypeDetailEng != null) throw new BusinessException(AbilityTargetTypeDetailEngMessages.AbilityTargetTypeShouldBeAvailableForCreate);
    }

}
