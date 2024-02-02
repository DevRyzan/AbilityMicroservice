using Domain.Abilities;

namespace Application.Service.AbilityServices.AbilityTargetTypeService;

public interface IAbilityTargetTypeService
{
    Task<AbilityTargetType> Create(AbilityTargetType abilityTargetType);
    Task<AbilityTargetType> Update(AbilityTargetType abilityTargetType);
    Task<AbilityTargetType> Delete(AbilityTargetType abilityTargetType);
    Task<AbilityTargetType> Remove(AbilityTargetType abilityTargetType);

    Task<AbilityTargetType> GetById(Guid id);
    Task<List<AbilityTargetType>> GetActiveList(int index = 0, int size = 10);
    Task<List<AbilityTargetType>> GetInActiveList(int index = 0, int size = 10);
}
