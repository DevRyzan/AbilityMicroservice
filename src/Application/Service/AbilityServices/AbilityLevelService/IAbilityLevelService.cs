using Domain.Abilities;

namespace Application.Service.AbilityServices.AbilityLevelService;

public interface IAbilityLevelService
{
    Task<AbilityLevel> Create(AbilityLevel abilityLevel);
    Task<AbilityLevel> Update(AbilityLevel abilityLevel);
    Task<AbilityLevel> Delete(AbilityLevel abilityLevel);
    Task<AbilityLevel> Remove(AbilityLevel abilityLevel);

    Task<AbilityLevel> GetById(Guid id);
    Task<List<AbilityLevel>> GetListByActive(int index = 0, int size = 10);
    Task<List<AbilityLevel>> GetListByInActive(int index = 0, int size = 10);
}
