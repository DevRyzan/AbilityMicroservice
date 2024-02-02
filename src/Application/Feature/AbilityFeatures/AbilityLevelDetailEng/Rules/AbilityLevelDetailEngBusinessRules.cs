using Application.Feature.AbilityFeatures.AbilityLevelDetailEng.Constants;
using Application.Service.Repositories;
using Core.Application;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Abilities;

namespace Application.Feature.AbilityFeatures.AbilityLevelDetailEng.Rules;

public class AbilityLevelDetailEngBusinessRules : BaseBusinessRules
{
    private readonly IAbilityLevelDetailEngRepository _abilityLevelDetailEngRepository;
    private readonly IAbilityLevelRepository _abilityLevelRepository;

    public AbilityLevelDetailEngBusinessRules(IAbilityLevelDetailEngRepository abilityLevelDetailEngRepository, IAbilityLevelRepository abilityLevelRepository)
    {
        _abilityLevelDetailEngRepository = abilityLevelDetailEngRepository;
        _abilityLevelRepository = abilityLevelRepository;
    }

    public async Task PageRequestShouldBeValid(int index, int size)
    {
        if (index < 0 || size <= 0) throw new BusinessException(AbilityLevelDetailEngMessages.PageRequestShouldBeValid);
    }
    public async Task IdShouldBeExist(Guid id)
    {
        Domain.Abilities.AbilityLevelDetailEng abilityLevelDetailEng = await _abilityLevelDetailEngRepository.GetAsync(x => x.Id.Equals(id));
        if (abilityLevelDetailEng == null) throw new BusinessException(AbilityLevelDetailEngMessages.IdShouldBeExist);
    }
    public async Task RemoveCondition(Guid id)
    {
        Domain.Abilities.AbilityLevelDetailEng abilityLevelDetailEng = await _abilityLevelDetailEngRepository.GetAsync(x => x.Id.Equals(id));
        if (abilityLevelDetailEng.Status == true || abilityLevelDetailEng.IsDeleted == false) throw new BusinessException(AbilityLevelDetailEngMessages.RemoveCondition);
    }


    public async Task AbilityLevelIdAlreadyHaveDetailForCreate(Guid abilityLevelId)
    {
        Domain.Abilities.AbilityLevelDetailEng abilityLevelDetailEng = await _abilityLevelDetailEngRepository.GetAsync(x => x.AbilityLevelId.Equals(abilityLevelId));
        if (abilityLevelDetailEng != null) throw new BusinessException(AbilityLevelDetailEngMessages.AbilityIdDontAsign);
    }

    public async Task AbilityLevelIdShouldBeExist(Guid abilityLevelId)
    {
        Domain.Abilities.AbilityLevelDetailEng abilityLevelDetailEng = await _abilityLevelDetailEngRepository.GetAsync(x => x.AbilityLevelId.Equals(abilityLevelId));
        if (abilityLevelDetailEng == null) throw new BusinessException(AbilityLevelDetailEngMessages.AbilityLevelShouldBeExist);
    }

    public async Task AbilityLevelShouldBeExist(Guid abilityLevelId)
    {
        Domain.Abilities.AbilityLevel abilityLevel = await _abilityLevelRepository.GetAsync(x => x.Id.Equals(abilityLevelId));
        if (abilityLevel == null) throw new BusinessException(AbilityLevelDetailEngMessages.AbilityLevelShouldBeExist);
    }
    public async Task AbilityLevelIdAlreadyHaveDetailForUpdate(Guid abilityLevelId,Guid Id)
    {
        Domain.Abilities.AbilityLevelDetailEng abilityLevelDetailEng = await _abilityLevelDetailEngRepository.GetAsync(x => x.AbilityLevelId.Equals(abilityLevelId) && !x.Id.Equals(Id));
        if (abilityLevelDetailEng != null) throw new BusinessException(AbilityLevelDetailEngMessages.AbilityIdDontAsign);
    }
}
