
using Domain.Abilities;


namespace Application.Service.AbilityServices.AbilityAffectUnitService;

public interface IAbilityAffectUnitService
{
    Task<AbilityAffectUnit> Create(AbilityAffectUnit abilityAffectUnit);
    Task<AbilityAffectUnit> Update(AbilityAffectUnit abilityAffectUnit);
    Task<AbilityAffectUnit> Delete(AbilityAffectUnit abilityAffectUnit);
    Task<AbilityAffectUnit> Remove(AbilityAffectUnit abilityAffectUnit);

    Task<AbilityAffectUnit> GetById(string id);

    Task<List<AbilityAffectUnit>> GetListByActive(int index = 0, int size = 10);
    Task<List<AbilityAffectUnit>> GetListByInActive(int index = 0, int size = 10);
}
