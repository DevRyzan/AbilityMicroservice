using Application.Service.Repositories;
using Domain.Abilities;

namespace Application.Service.AbilityServices.AbilityLevelDetailEngService;

public class AbilityLevelDetailEngManager : IAbilityLevelDetailEngService
{
    private readonly IAbilityLevelDetailEngRepository _abilityLevelDetailEngRepository;

    public AbilityLevelDetailEngManager(IAbilityLevelDetailEngRepository abilityLevelDetailEngRepository)
    {
        _abilityLevelDetailEngRepository = abilityLevelDetailEngRepository;
    }

    public async Task<AbilityLevelDetailEng> Create(AbilityLevelDetailEng abilityLevelDetailEng)
    {

        return await _abilityLevelDetailEngRepository.AddAsync(abilityLevelDetailEng);
    }

    public async Task<AbilityLevelDetailEng> Delete(AbilityLevelDetailEng abilityLevelDetailEng)
    {
        return await _abilityLevelDetailEngRepository.UpdateAsync(abilityLevelDetailEng.Id, abilityLevelDetailEng);
    }

    public async Task<AbilityLevelDetailEng> GetByAbilityLevelId(Guid abilityLevelId)
    {
        return await _abilityLevelDetailEngRepository.GetAsync(x => x.AbilityLevelId.Equals(abilityLevelId));
    }

    public async Task<AbilityLevelDetailEng> GetById(Guid id)
    {
        return await _abilityLevelDetailEngRepository.GetAsync(x => x.Id.Equals(id));
    }

    public async Task<List<AbilityLevelDetailEng>> GetListByActive(int index = 0, int size = 10)
    {
        return await _abilityLevelDetailEngRepository.GetList(x => x.Status.Equals(true), index: index, size: size);
    }

    public async Task<List<AbilityLevelDetailEng>> GetListByInActive(int index = 0, int size = 10)
    {
        return await _abilityLevelDetailEngRepository.GetList(x => x.Status.Equals(false), index: index, size: size);
    }

    public async Task<AbilityLevelDetailEng> Remove(AbilityLevelDetailEng abilityLevelDetailEng)
    {
        return await _abilityLevelDetailEngRepository.DeleteAsync(abilityLevelDetailEng);
    }

    public async Task<AbilityLevelDetailEng> Update(AbilityLevelDetailEng abilityLevelDetailEng)
    {
        return await _abilityLevelDetailEngRepository.UpdateAsync(abilityLevelDetailEng.Id, abilityLevelDetailEng);
    }
}
