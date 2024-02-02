using Application.Service.Repositories;
using Domain.Abilities;

namespace Application.Service.AbilityServices.AbilityTargetTypeDetailEngService;

public class AbilityTargetTypeDetailEngManager : IAbilityTargetTypeDetailEngService
{
    private readonly IAbilityTargetTypeDetailEngRepository _abilityTargetTypeDetailEngRepository;

    public AbilityTargetTypeDetailEngManager(IAbilityTargetTypeDetailEngRepository abilityTargetTypeDetailEngRepository)
    {
        _abilityTargetTypeDetailEngRepository = abilityTargetTypeDetailEngRepository;
    }

    public async Task<AbilityTargetTypeDetailEng> Create(AbilityTargetTypeDetailEng abilityTargetTypeDetailEng)
    {
        return await _abilityTargetTypeDetailEngRepository.AddAsync(abilityTargetTypeDetailEng);
    }

    public async Task<AbilityTargetTypeDetailEng> Delete(AbilityTargetTypeDetailEng abilityTargetTypeDetailEng)
    {
        return await _abilityTargetTypeDetailEngRepository.UpdateAsync(abilityTargetTypeDetailEng.Id,abilityTargetTypeDetailEng);
    }

    public async Task<List<AbilityTargetTypeDetailEng>> GetActiveList(int index = 0, int size = 10)
    {
        return await _abilityTargetTypeDetailEngRepository.GetList(x => x.Status.Equals(true),index:index,size:size);
    }

    public async Task<AbilityTargetTypeDetailEng> GetById(Guid id)
    {
        return await _abilityTargetTypeDetailEngRepository.GetAsync(x => x.Id.Equals(id));
    }

    public async Task<List<AbilityTargetTypeDetailEng>> GetInActiveList(int index = 0, int size = 10)
    {
        return await _abilityTargetTypeDetailEngRepository.GetList(x => x.Status.Equals(false), index: index, size: size);
    }

    public async Task<AbilityTargetTypeDetailEng> Remove(AbilityTargetTypeDetailEng abilityTargetTypeDetailEng)
    {
        return await _abilityTargetTypeDetailEngRepository.DeleteAsync(abilityTargetTypeDetailEng);
    }

    public async Task<AbilityTargetTypeDetailEng> Update(AbilityTargetTypeDetailEng abilityTargetTypeDetailEng)
    {
        return await _abilityTargetTypeDetailEngRepository.UpdateAsync(abilityTargetTypeDetailEng.Id, abilityTargetTypeDetailEng);
    }
}
