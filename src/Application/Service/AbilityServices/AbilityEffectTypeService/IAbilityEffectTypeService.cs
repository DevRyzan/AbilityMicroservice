
using Domain.Abilities;

namespace Application.Service.AbilityServices.AbilityEffectTypeService;

public interface IAbilityEffectTypeService
{
    Task<AbilityEffectType> Create(AbilityEffectType abilityEffectType);
    Task<AbilityEffectType> Update(AbilityEffectType abilityEffectType);
    Task<AbilityEffectType> Delete(AbilityEffectType abilityEffectType);
    Task<AbilityEffectType> Remove(AbilityEffectType abilityEffectType);

    Task<AbilityEffectType> GetById(string id);
    Task<List<AbilityEffectType>> GetListByActive(int index = 0, int size = 10);
    Task<List<AbilityEffectType>> GetListByInActive(int index = 0, int size = 10);
}
