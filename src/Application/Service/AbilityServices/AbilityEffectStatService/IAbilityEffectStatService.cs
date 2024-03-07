
using Domain.Abilities;

namespace Application.Service.AbilityServices.AbilityEffectStatService;

public interface IAbilityEffectStatService
{
    Task<AbilityEffectStat> Create(AbilityEffectStat abilityEffectStat);
    Task<AbilityEffectStat> Update(AbilityEffectStat abilityEffectStat);
    Task<AbilityEffectStat> Delete(AbilityEffectStat abilityEffectStat);
    Task<AbilityEffectStat> Remove(AbilityEffectStat abilityEffectStat);
         
    Task<AbilityEffectStat> GetById(string id);

    Task<List<AbilityEffectStat>> GetListByActive(int index = 0, int size = 10);
    Task<List<AbilityEffectStat>> GetListByInActive(int index = 0, int size = 10);
}
