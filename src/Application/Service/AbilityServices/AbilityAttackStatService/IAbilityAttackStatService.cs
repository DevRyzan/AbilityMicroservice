

using Domain.Abilities;

namespace Application.Service.AbilityServices.AbilityAttackStatService;

public interface IAbilityAttackStatService
{
    Task<AbilityAttackStat> Create(AbilityAttackStat abilityAttackStat);
    Task<AbilityAttackStat> Update(AbilityAttackStat abilityAttackStat);
    Task<AbilityAttackStat> Delete(AbilityAttackStat abilityAttackStat);
    Task<AbilityAttackStat> Remove(AbilityAttackStat abilityAttackStat);

    Task<AbilityAttackStat> GetById(string id);

    Task<List<AbilityAttackStat>> GetListByActive(int index = 0, int size = 10);
    Task<List<AbilityAttackStat>> GetListByInActive(int index = 0, int size = 10);

}
