using Application.Service.Repositories;
using Domain.Abilities;


namespace Application.Service.AbilityServices.AbilityEffectDisableTypeService;

public class AbilityEffectDisableTypeManager : IAbilityEffectDisableTypeService
{
    private readonly IAbilityEffectDisableTypeRepository _abilityEffectDisableTypeRepository;

    public AbilityEffectDisableTypeManager(IAbilityEffectDisableTypeRepository abilityEffectDisableTypeRepository)
    {
        _abilityEffectDisableTypeRepository = abilityEffectDisableTypeRepository;
    }

    public async Task<AbilityEffectDisableType> Create(AbilityEffectDisableType abilityEffectDisableType)
    {
        return await _abilityEffectDisableTypeRepository.AddAsync(abilityEffectDisableType);
    }
    public async Task<AbilityEffectDisableType> Remove(AbilityEffectDisableType abilityEffectDisableType)
    {
        return await _abilityEffectDisableTypeRepository.UpdateAsync(abilityEffectDisableType.Id, abilityEffectDisableType);
    }
    public async Task<AbilityEffectDisableType> Update(AbilityEffectDisableType abilityEffectDisableType)
    {
        return await _abilityEffectDisableTypeRepository.UpdateAsync(abilityEffectDisableType.Id, abilityEffectDisableType);
    }
    public async Task<AbilityEffectDisableType> Delete(AbilityEffectDisableType abilityEffectDisableType)
    {
        return await _abilityEffectDisableTypeRepository.UpdateAsync(abilityEffectDisableType.Id, abilityEffectDisableType);
    }
    public async Task<AbilityEffectDisableType> GetById(string id)
    {
        return await _abilityEffectDisableTypeRepository.GetAsync(x => x.Id.Equals(id));
    }
    public async Task<List<AbilityEffectDisableType>> GetListByActive(int index = 0, int size = 10)
    {
        return await _abilityEffectDisableTypeRepository.GetList(x => x.Status.Equals(true), index: index, size: size);
    }
    public async Task<List<AbilityEffectDisableType>> GetListByInActive(int index = 0, int size = 10)
    {
        return await _abilityEffectDisableTypeRepository.GetList(x => x.Status.Equals(false), index: index, size: size);
    }

}
