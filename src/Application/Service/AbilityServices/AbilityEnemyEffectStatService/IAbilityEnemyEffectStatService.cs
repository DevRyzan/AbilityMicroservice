
using Domain.Abilities;

namespace Application.Service.AbilityServices.AbilityEnemyEffectStatService;

public interface IAbilityEnemyEffectStatService
{
    Task<AbilityEnemyEffectStat> Create(AbilityEnemyEffectStat abilityEnemyEffectStat);
    Task<AbilityEnemyEffectStat> Update(AbilityEnemyEffectStat abilityEnemyEffectStat);
    Task<AbilityEnemyEffectStat> Delete(AbilityEnemyEffectStat abilityEnemyEffectStat);
    Task<AbilityEnemyEffectStat> Remove(AbilityEnemyEffectStat abilityEnemyEffectStat);

    Task<AbilityEnemyEffectStat> GetById(string id);
    Task<List<AbilityEnemyEffectStat>> GetListByActive(int index = 0, int size = 10);
    Task<List<AbilityEnemyEffectStat>> GetListByInActive(int index = 0, int size = 10);
}
