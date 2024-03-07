

using Domain.Abilities;

namespace Application.Service.AbilityServices.AbilityActivationTypeService;

public interface IAbilityActivationTypeService
{
    Task<AbilityActivationType> Create(AbilityActivationType abilityActivationType);
    Task<AbilityActivationType> Update(AbilityActivationType abilityActivationType);
    Task<AbilityActivationType> Delete(AbilityActivationType abilityActivationType);
    Task<AbilityActivationType> Remove(AbilityActivationType abilityActivationType);
         
    Task<AbilityActivationType> GetById(string id);

    Task<List<AbilityActivationType>> GetListByActive(int index = 0, int size = 10);
    Task<List<AbilityActivationType>> GetListByInActive(int index = 0, int size = 10);
}
