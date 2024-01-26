using Application.Service.Repositories;
using Core.Persistence.Paging;
using Domain.Abilities;

namespace Application.Service.AbilityServices.AbilityService;

public class AbilityManager : IAbilityService
{
    private readonly IAbilityRepository _abilityRepository;

    public AbilityManager(IAbilityRepository abilityRepository)
    {
        _abilityRepository = abilityRepository;
    }

    public async Task<Ability> Create(Ability ability)
    {
        return await _abilityRepository.AddAsync(ability);
    }

    public Task<Ability> Delete(Ability ability)
    {
        throw new NotImplementedException();
    }

    public Task<List<AbilityAndAbilityCategory>> GetAbilityAndCategoryById(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<List<AbilityAndAbilityCategory>> GetAbilityAndCategoryByIdAndStatusFalse(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<List<AbilityAndAbilityCategory>> GetAbilityAndCategoryByIdAndStatusTrue(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<List<AbilityAndAbilityCombo>> GetAbilityAndCombosById(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<List<AbilityAndAbilityCombo>> GetAbilityAndCombosByIdAndStatusFalse(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<List<AbilityAndAbilityCombo>> GetAbilityAndCombosByIdAndStatusTrue(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<List<AbilityAndAbilityLevel>> GetAbilityAndLevelById(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<List<AbilityAndAbilityLevel>> GetAbilityAndLevelByIdAndStatusFalse(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<List<AbilityAndAbilityLevel>> GetAbilityAndLevelByIdAndStatusTrue(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<List<AbilityEffectStat>> GetAbilityEffectStatsById(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<List<AbilityEffectStat>> GetAbilityEffectStatsByIdAndStatusFalse(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<List<AbilityEffectStat>> GetAbilityEffectStatsByIdAndStatusTrue(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IPaginate<Ability>> GetActiveList(int index = 0, int size = 10)
    {
        throw new NotImplementedException();
    }

    public Task<Ability> GetByAbilityId(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<Ability> GetByHeroId(Guid heroId)
    {
        throw new NotImplementedException();
    }

    public Task<Ability> GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<Ability> GetByIdStatusFalse(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<Ability> GetByIdStatusTrue(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<Ability> GetByName(string name)
    {
        throw new NotImplementedException();
    }

    public Task<IPaginate<Ability>> GetInActiveList(int index = 0, int size = 10)
    {
        throw new NotImplementedException();
    }

    public Task<IPaginate<Ability>> GetListByAbilityComboId(Guid abilityComboId, int index = 0, int size = 10)
    {
        throw new NotImplementedException();
    }

    public Task<IPaginate<Ability>> GetListByAbilityLevelId(Guid abilityLevelId, int index = 0, int size = 10)
    {
        throw new NotImplementedException();
    }

    public Task<IPaginate<Ability>> GetListByEffectTypeId(Guid effectTypeId, int index = 0, int size = 10)
    {
        throw new NotImplementedException();
    }

    public Task<Ability> Remove(Ability ability)
    {
        throw new NotImplementedException();
    }

    public async Task<Ability> Update(Ability ability)
    {
        return await _abilityRepository.UpdateAsync(ability.Id,ability);
    }
}
