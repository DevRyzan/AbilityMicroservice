

using Domain.Abilities;

namespace Application.Service.AbilityServices.AbilityEffectService;

public interface IAbilityEffectService
{
    Task<AbilityEffect> Create(AbilityEffect abilityEffect);
    Task<AbilityEffect> Update(AbilityEffect abilityEffect);
    Task<AbilityEffect> Delete(AbilityEffect abilityEffect);
    Task<AbilityEffect> Remove(AbilityEffect abilityEffect);
         
    Task<AbilityEffect> GetById(string id);

    Task<List<AbilityEffect>> GetListByActive(int index = 0, int size = 10);
    Task<List<AbilityEffect>> GetListByInActive(int index = 0, int size = 10);
}
