using Application.Service.Repositories;
using Domain.Abilities;

namespace Application.Service.AbilityServices.AbilityDamageTypeService;

public class AbilityDamageTypeManager : IAbilityDamageTypeService
{
    private readonly IAbilityDamageTypeRepository _abilityDamageTypeRepository;

    public AbilityDamageTypeManager(IAbilityDamageTypeRepository abilityDamageTypeRepository)
    {
        _abilityDamageTypeRepository = abilityDamageTypeRepository;
    }

    public async Task<AbilityDamageType> Create(AbilityDamageType abilityDamageType)
    {
        return await _abilityDamageTypeRepository.AddAsync(abilityDamageType);
    }

    public async Task<AbilityDamageType> Delete(AbilityDamageType abilityDamageType)
    {
        return await _abilityDamageTypeRepository.UpdateAsync(abilityDamageType.Id, abilityDamageType);
    }
    public async Task<AbilityDamageType> Remove(AbilityDamageType abilityDamageType)
    {
        return await _abilityDamageTypeRepository.UpdateAsync(abilityDamageType.Id, abilityDamageType);
    }

    public async Task<AbilityDamageType> Update(AbilityDamageType abilityDamageType)
    {
        return await _abilityDamageTypeRepository.UpdateAsync(abilityDamageType.Id, abilityDamageType);
    }

    public async Task<AbilityDamageType> GetById(string id)
    {
        return await _abilityDamageTypeRepository.GetAsync(x => x.Id.Equals(id));
    }

    public async Task<List<AbilityDamageType>> GetListByActive(int index = 0, int size = 10)
    {
        return await _abilityDamageTypeRepository.GetList(x => x.Status.Equals(true), index: index, size: size);
    }

    public async Task<List<AbilityDamageType>> GetListByInActive(int index = 0, int size = 10)
    {
        return await _abilityDamageTypeRepository.GetList(x => x.Status.Equals(false), index: index, size: size);
    }
}
