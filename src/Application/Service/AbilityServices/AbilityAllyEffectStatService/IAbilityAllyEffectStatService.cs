

using Domain.Abilities;

namespace Application.Service.AbilityServices.AbilityAllyEffectStatService;

public interface IAbilityAllyEffectStatService
{
    Task<AbilityAllyEffectStat> Create(AbilityAllyEffectStat abilityAllyEffectStat);
    Task<AbilityAllyEffectStat> Update(AbilityAllyEffectStat abilityAllyEffectStat);
    Task<AbilityAllyEffectStat> Delete(AbilityAllyEffectStat abilityAllyEffectStat);
    Task<AbilityAllyEffectStat> Remove(AbilityAllyEffectStat abilityAllyEffectStat);
         
    Task<AbilityAllyEffectStat> GetById(string id);

    Task<List<AbilityAllyEffectStat>> GetListByActive(int index = 0, int size = 10);
    Task<List<AbilityAllyEffectStat>> GetListByInActive(int index = 0, int size = 10);
}
