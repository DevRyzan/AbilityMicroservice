

using Domain.Abilities;

namespace Application.Service.AbilityServices.AbilityTypeService;

public interface IAbilityTypeService
{
    Task<AbilityType> Create(AbilityType abilityType);
    Task<AbilityType> Update(AbilityType abilityType);
    Task<AbilityType> Delete(AbilityType abilityType);
    Task<AbilityType> Remove(AbilityType abilityType);
         
    Task<AbilityType> GetById(string id);
    Task<List<AbilityType>> GetActiveList(int index = 0, int size = 10);
    Task<List<AbilityType>> GetInActiveList(int index = 0, int size = 10);
}
