using Application.Service.Repositories;
using Domain.Abilities;


namespace Application.Service.AbilityServices.AbilityAffectUnitService;

public class AbilityAffectUnitManager : IAbilityAffectUnitService
{
    private readonly IAbilityAffectUnitRepository _abilityAffectUnitRepository;

    public AbilityAffectUnitManager(IAbilityAffectUnitRepository abilityAffectUnitRepository)
    {
        _abilityAffectUnitRepository = abilityAffectUnitRepository;
    }

    public async Task<AbilityAffectUnit> Create(AbilityAffectUnit abilityAffectUnit)
    {
        return await _abilityAffectUnitRepository.AddAsync(abilityAffectUnit);
    }

    public async Task<AbilityAffectUnit> Delete(AbilityAffectUnit abilityAffectUnit)
    {
        return await _abilityAffectUnitRepository.UpdateAsync(abilityAffectUnit.Id, abilityAffectUnit);
    }
    public async Task<AbilityAffectUnit> Remove(AbilityAffectUnit abilityAffectUnit)
    {
        return await _abilityAffectUnitRepository.DeleteAsync(abilityAffectUnit);
    }
    public async Task<AbilityAffectUnit> Update(AbilityAffectUnit abilityAffectUnit)
    {
        return await _abilityAffectUnitRepository.UpdateAsync(id: abilityAffectUnit.Id, entity: abilityAffectUnit);
    }
    public async Task<AbilityAffectUnit> GetById(string id)
    {
        return await _abilityAffectUnitRepository.GetAsync(x => x.Id.Equals(id));
    }

    public async Task<List<AbilityAffectUnit>> GetListByActive(int index = 0, int size = 10)
    {
        return await _abilityAffectUnitRepository.GetList(x => x.Status.Equals(true), index: index, size: size);
    }

    public async Task<List<AbilityAffectUnit>> GetListByInActive(int index = 0, int size = 10)
    {
        return await _abilityAffectUnitRepository.GetList(x => x.Status.Equals(false), index: index, size: size);
    }

}
