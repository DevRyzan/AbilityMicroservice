using Domain.Abilities;

namespace Application.Service.AbilityServices.AbilityLevelDetailEngService;

public interface IAbilityLevelDetailEngService
{
    Task<AbilityLevelDetailEng> Create(AbilityLevelDetailEng abilityLevelDetailEng);
    Task<AbilityLevelDetailEng> Update(AbilityLevelDetailEng abilityLevelDetailEng);
    Task<AbilityLevelDetailEng> Delete(AbilityLevelDetailEng abilityLevelDetailEng);
    Task<AbilityLevelDetailEng> Remove(AbilityLevelDetailEng abilityLevelDetailEng);

    Task<AbilityLevelDetailEng> GetById(Guid id);
    Task<AbilityLevelDetailEng> GetByAbilityLevelId(Guid abilityLevelId);
    Task<List<AbilityLevelDetailEng>> GetListByActive(int index = 0, int size = 10);
    Task<List<AbilityLevelDetailEng>> GetListByInActive(int index = 0, int size = 10);
}
