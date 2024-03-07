using Application.Service.Repositories;
using Domain.Abilities;

namespace Application.Service.AbilityServices.AbilityEffectStatService;

public class AbilityEffectStatManager : IAbilityEffectStatService
{
    private readonly IAbilityEffectStatRepository _abilityEffectStatRepository;

    public AbilityEffectStatManager(IAbilityEffectStatRepository abilityEffectStatRepository)
    {
        _abilityEffectStatRepository = abilityEffectStatRepository;
    }

    public async Task<AbilityEffectStat> Create(AbilityEffectStat abilityEffectStat)
    {
        return await _abilityEffectStatRepository.AddAsync(abilityEffectStat);
    }
    public async Task<AbilityEffectStat> Delete(AbilityEffectStat abilityEffectStat)
    {
        return await _abilityEffectStatRepository.UpdateAsync(abilityEffectStat.Id, abilityEffectStat);
    }
    public async Task<AbilityEffectStat> Remove(AbilityEffectStat abilityEffectStat)
    {
        return await _abilityEffectStatRepository.DeleteAsync(abilityEffectStat);
    }
    public async Task<AbilityEffectStat> Update(AbilityEffectStat abilityEffectStat)
    {
        return await _abilityEffectStatRepository.UpdateAsync(abilityEffectStat.Id, abilityEffectStat);
    }
    public async Task<AbilityEffectStat> GetById(string id)
    {
        return await _abilityEffectStatRepository.GetAsync(x => x.Id.Equals(id));
    }
    public async Task<List<AbilityEffectStat>> GetListByActive(int index = 0, int size = 10)
    {
        return await _abilityEffectStatRepository.GetList(x => x.Status.Equals(true), index: index, size: size);
    }
    public async Task<List<AbilityEffectStat>> GetListByInActive(int index = 0, int size = 10)
    {
        return await _abilityEffectStatRepository.GetList(x => x.Status.Equals(false), index: index, size: size);
    }
}
