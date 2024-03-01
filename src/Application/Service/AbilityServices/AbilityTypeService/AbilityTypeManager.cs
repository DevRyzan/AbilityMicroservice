using Application.Service.Repositories;
using Domain.Abilities;


namespace Application.Service.AbilityServices.AbilityTypeService;

public class AbilityTypeManager : IAbilityTypeService
{
    private readonly IAbilityTypeRepository _abilityTypeRepository;

    public AbilityTypeManager(IAbilityTypeRepository abilityTypeRepository)
    {
        _abilityTypeRepository = abilityTypeRepository;
    }

    public async Task<AbilityType> Create(AbilityType abilityType)
    {
        return await _abilityTypeRepository.AddAsync(abilityType);
    }

    public async Task<AbilityType> Delete(AbilityType abilityType)
    {
        return await _abilityTypeRepository.UpdateAsync(abilityType.Id, abilityType);
    }

    public async Task<AbilityType> Remove(AbilityType abilityType)
    {
        return await _abilityTypeRepository.DeleteAsync(abilityType);
    }

    public async Task<AbilityType> Update(AbilityType abilityType)
    {
        return await _abilityTypeRepository.UpdateAsync(abilityType.Id, abilityType);
    }
    public async Task<AbilityType> GetById(string id)
    {
        return await _abilityTypeRepository.GetAsync(x => x.Id.Equals(id));
    }

    public async Task<List<AbilityType>> GetActiveList(int index = 0, int size = 10)
    {
        return await _abilityTypeRepository.GetList(x => x.Status.Equals(true), index: index, size: size);
    }

    public async Task<List<AbilityType>> GetInActiveList(int index = 0, int size = 10)
    {
        return await _abilityTypeRepository.GetList(x => x.Status.Equals(false), index: index, size: size);
    }
}
