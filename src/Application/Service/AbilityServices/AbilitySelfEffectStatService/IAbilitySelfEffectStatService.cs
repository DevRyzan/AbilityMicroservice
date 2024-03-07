using Domain.Abilities;


namespace Application.Service.AbilityServices.AbilitySelfEffectStatService;

public interface IAbilitySelfEffectStatService
{
    Task<AbilitySelfEffectStat> Create(AbilitySelfEffectStat abilitySelfEffectStat);
    Task<AbilitySelfEffectStat> Update(AbilitySelfEffectStat abilitySelfEffectStat);
    Task<AbilitySelfEffectStat> Delete(AbilitySelfEffectStat abilitySelfEffectStat);
    Task<AbilitySelfEffectStat> Remove(AbilitySelfEffectStat abilitySelfEffectStat);

    Task<AbilitySelfEffectStat> GetById(string id);
    Task<List<AbilitySelfEffectStat>> GetListByActive(int index = 0, int size = 10);
    Task<List<AbilitySelfEffectStat>> GetListByInActive(int index = 0, int size = 10);
}
