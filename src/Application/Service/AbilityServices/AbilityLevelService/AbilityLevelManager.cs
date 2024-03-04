using Application.Service.Repositories;
using Domain.Abilities;

namespace Application.Service.AbilityServices.AbilityLevelService;

public class AbilityLevelManager : IAbilityLevelService
{
    public IAbilityLevelRepository _abilityLevelRepository { get; set; }
    public AbilityLevelManager(IAbilityLevelRepository abilityLevelRepository)
    {
        _abilityLevelRepository = abilityLevelRepository;
    }

    public async Task<AbilityLevel> Create(AbilityLevel abilityLevel)
    {
        return await _abilityLevelRepository.AddAsync(abilityLevel);
    }

    public async Task<AbilityLevel> Delete(AbilityLevel abilityLevel)
    {
        return await _abilityLevelRepository.UpdateAsync(abilityLevel.Id,abilityLevel);
    }

    public async Task<AbilityLevel> GetById(string id)
    {
        return await _abilityLevelRepository.GetAsync(x => x.Id.Equals(id));
    }

    public async Task<List<AbilityLevel>> GetListByActive(int index = 0, int size = 10)
    {
        return await _abilityLevelRepository.GetList(x => x.Status.Equals(true), index: index, size: size);
    }

    public async Task<List<AbilityLevel>> GetListByInActive(int index = 0, int size = 10)
    {
        return await _abilityLevelRepository.GetList(x => x.Status.Equals(false), index: index, size: size);
    }

    public async Task<AbilityLevel> Remove(AbilityLevel abilityLevel)
    {
        return await _abilityLevelRepository.DeleteAsync(abilityLevel);
    }

    public async Task<AbilityLevel> Update(AbilityLevel abilityLevel)
    {
        return await _abilityLevelRepository.UpdateAsync(abilityLevel.Id, abilityLevel);
    }
}
