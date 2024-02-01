using Application.Service.Repositories;
using Domain.Abilities;

namespace Application.Service.AbilityServices.AbilityTargetTypeService;

public class AbilityTargetTypeManager : IAbilityTargetTypeService
{
    private readonly IAbilityTargetTypeRepository _abilityTargetTypeRepository;

    public AbilityTargetTypeManager(IAbilityTargetTypeRepository abilityTargetTypeRepository)
    {
        _abilityTargetTypeRepository = abilityTargetTypeRepository;
    }

    public async Task<AbilityTargetType> Create(AbilityTargetType abilityTargetType)
    {
        return await _abilityTargetTypeRepository.AddAsync(abilityTargetType);
    }

    public async Task<AbilityTargetType> Delete(AbilityTargetType abilityTargetType)
    {
        return await _abilityTargetTypeRepository.UpdateAsync(abilityTargetType.Id,abilityTargetType);
    }

    public async Task<List<AbilityTargetType>> GetActiveList(int index = 0, int size = 10)
    {
        return await _abilityTargetTypeRepository.GetList(x => x.Status.Equals(true),index:index,size:size);
    }

    public async Task<AbilityTargetType> GetById(Guid id)
    {
        return await _abilityTargetTypeRepository.GetAsync(x => x.Id.Equals(id));
    }

    public async Task<List<AbilityTargetType>> GetInActiveList(int index = 0, int size = 10)
    {
        return await _abilityTargetTypeRepository.GetList(x => x.Status.Equals(false), index: index, size: size);
    }

    public async Task<AbilityTargetType> Remove(AbilityTargetType abilityTargetType)
    {
        return await _abilityTargetTypeRepository.DeleteAsync(abilityTargetType);
    }

    public async Task<AbilityTargetType> Update(AbilityTargetType abilityTargetType)
    {
        return await _abilityTargetTypeRepository.UpdateAsync(abilityTargetType.Id,abilityTargetType);
    }
}
