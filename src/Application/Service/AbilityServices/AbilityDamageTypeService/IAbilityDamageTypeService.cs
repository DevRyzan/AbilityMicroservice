

using Domain.Abilities;

namespace Application.Service.AbilityServices.AbilityDamageTypeService;

public interface IAbilityDamageTypeService
{
    Task<AbilityDamageType> Create(AbilityDamageType abilityDamageType);
    Task<AbilityDamageType> Update(AbilityDamageType abilityDamageType);
    Task<AbilityDamageType> Delete(AbilityDamageType abilityDamageType);
    Task<AbilityDamageType> Remove(AbilityDamageType abilityDamageType);

    Task<AbilityDamageType> GetById(string id);
    Task<List<AbilityDamageType>> GetListByActive(int index = 0, int size = 10);
    Task<List<AbilityDamageType>> GetListByInActive(int index = 0, int size = 10);
}
