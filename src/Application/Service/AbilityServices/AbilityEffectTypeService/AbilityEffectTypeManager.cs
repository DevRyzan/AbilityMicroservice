using Application.Service.Repositories;
using Domain.Abilities;


namespace Application.Service.AbilityServices.AbilityEffectTypeService;

public class AbilityEffectTypeManager : IAbilityEffectTypeService
{
    private readonly IAbilityEffectTypeRepository _abilityEffectTypeRepository;

    public AbilityEffectTypeManager(IAbilityEffectTypeRepository abilityEffectTypeRepository)
    {
        _abilityEffectTypeRepository = abilityEffectTypeRepository;
    }

    public async Task<AbilityEffectType> Create(AbilityEffectType abilityEffectType)
    {
        return await _abilityEffectTypeRepository.AddAsync(abilityEffectType);
    }
    public async Task<AbilityEffectType> Remove(AbilityEffectType abilityEffectType)
    {
        return await _abilityEffectTypeRepository.UpdateAsync(abilityEffectType.Id, abilityEffectType);
    }

    public async Task<AbilityEffectType> Update(AbilityEffectType abilityEffectType)
    {
        return await _abilityEffectTypeRepository.UpdateAsync(abilityEffectType.Id, abilityEffectType);
    }

    public async Task<AbilityEffectType> Delete(AbilityEffectType abilityEffectType)
    {
        return await _abilityEffectTypeRepository.UpdateAsync(abilityEffectType.Id, abilityEffectType);
    }

    public async Task<AbilityEffectType> GetById(string id)
    {
        return await _abilityEffectTypeRepository.GetAsync(x => x.Id.Equals(id));
    }

    public async Task<List<AbilityEffectType>> GetListByActive(int index = 0, int size = 10)
    {
        return await _abilityEffectTypeRepository.GetList(x => x.Status.Equals(true), index: index, size: size);
    }

    public async Task<List<AbilityEffectType>> GetListByInActive(int index = 0, int size = 10)
    {
        return await _abilityEffectTypeRepository.GetList(x => x.Status.Equals(false), index: index, size: size);
    }
}
