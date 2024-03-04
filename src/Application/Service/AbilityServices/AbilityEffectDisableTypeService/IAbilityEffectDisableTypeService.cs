using Domain.Abilities;


namespace Application.Service.AbilityServices.AbilityEffectDisableTypeService;

public interface IAbilityEffectDisableTypeService
{
    Task<AbilityEffectDisableType> Create(AbilityEffectDisableType abilityEffectDisableType);
    Task<AbilityEffectDisableType> Update(AbilityEffectDisableType abilityEffectDisableType);
    Task<AbilityEffectDisableType> Delete(AbilityEffectDisableType abilityEffectDisableType);
    Task<AbilityEffectDisableType> Remove(AbilityEffectDisableType abilityEffectDisableType);

    Task<AbilityEffectDisableType> GetById(string id);
    Task<List<AbilityEffectDisableType>> GetListByActive(int index = 0, int size = 10);
    Task<List<AbilityEffectDisableType>> GetListByInActive(int index = 0, int size = 10);

}
