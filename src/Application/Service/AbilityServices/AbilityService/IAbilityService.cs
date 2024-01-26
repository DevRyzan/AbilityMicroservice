using Core.Persistence.Paging;
using Domain.Abilities;

namespace Application.Service.AbilityServices.AbilityService;

public interface IAbilityService
{
    Task<Ability> Create(Ability ability);
    Task<Ability> Update(Ability ability);
    Task<Ability> Delete(Ability ability);
    Task<Ability> Remove(Ability ability);

    Task<Ability> GetById(Guid id);
    Task<Ability> GetByName(string name);
    Task<Ability> GetByIdStatusTrue(Guid id);
    Task<Ability> GetByIdStatusFalse(Guid id);
    Task<IPaginate<Ability>> GetListByAbilityLevelId(Guid abilityLevelId, int index = 0, int size = 10);
    Task<IPaginate<Ability>> GetListByAbilityComboId(Guid abilityComboId, int index = 0, int size = 10);
    Task<IPaginate<Ability>> GetListByEffectTypeId(Guid effectTypeId, int index = 0, int size = 10);
    Task<Ability> GetByHeroId(Guid heroId);
    Task<Ability> GetByAbilityId(Guid id);



    Task<List<AbilityAndAbilityCategory>> GetAbilityAndCategoryById(Guid id);
    Task<List<AbilityAndAbilityLevel>> GetAbilityAndLevelById(Guid id);
    Task<List<AbilityAndAbilityCombo>> GetAbilityAndCombosById(Guid id);
    Task<List<AbilityEffectStat>> GetAbilityEffectStatsById(Guid id);

    Task<IPaginate<Ability>> GetActiveList(int index = 0, int size = 10);
    Task<IPaginate<Ability>> GetInActiveList(int index = 0, int size = 10);

    #region True 
    Task<List<AbilityAndAbilityCategory>> GetAbilityAndCategoryByIdAndStatusTrue(Guid id);
    Task<List<AbilityAndAbilityLevel>> GetAbilityAndLevelByIdAndStatusTrue(Guid id);
    Task<List<AbilityAndAbilityCombo>> GetAbilityAndCombosByIdAndStatusTrue(Guid id);
    Task<List<AbilityEffectStat>> GetAbilityEffectStatsByIdAndStatusTrue(Guid id);
    #endregion

    #region False 
    Task<List<AbilityAndAbilityCategory>> GetAbilityAndCategoryByIdAndStatusFalse(Guid id);
    Task<List<AbilityAndAbilityLevel>> GetAbilityAndLevelByIdAndStatusFalse(Guid id);
    Task<List<AbilityAndAbilityCombo>> GetAbilityAndCombosByIdAndStatusFalse(Guid id);
    Task<List<AbilityEffectStat>> GetAbilityEffectStatsByIdAndStatusFalse(Guid id);

    #endregion
}
