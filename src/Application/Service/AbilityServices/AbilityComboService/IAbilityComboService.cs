using Domain.Abilities;

namespace Application.Service.AbilityServices.AbilityComboService;

public interface IAbilityComboService
{
    Task<AbilityCombo> Create(AbilityCombo abilityCombo);
    Task<AbilityCombo> Update(AbilityCombo abilityCombo);
    Task<AbilityCombo> Delete(AbilityCombo abilityCombo);
    Task<AbilityCombo> Remove(AbilityCombo abilityCombo);

    Task<AbilityCombo> GetById(string id);

    Task<List<AbilityCombo>> GetListByActive(int index = 0, int size = 10);
    Task<List<AbilityCombo>> GetListByInActive(int index = 0, int size = 10);
}
