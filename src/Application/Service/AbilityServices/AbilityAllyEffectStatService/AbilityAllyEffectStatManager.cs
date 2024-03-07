
using Application.Service.Repositories;
using Domain.Abilities;

namespace Application.Service.AbilityServices.AbilityAllyEffectStatService;

public class AbilityAllyEffectStatManager : IAbilityAllyEffectStatService
{
    private readonly IAbilityAllyEffectStatRepository _abilityAllyEffectStatRepository;

    public AbilityAllyEffectStatManager(IAbilityAllyEffectStatRepository abilityAllyEffectStatRepository)
    {
        _abilityAllyEffectStatRepository = abilityAllyEffectStatRepository;
    }

    public async Task<AbilityAllyEffectStat> Create(AbilityAllyEffectStat abilityAllyEffectStat)
    {
        return await _abilityAllyEffectStatRepository.AddAsync(abilityAllyEffectStat);
    }

    public async Task<AbilityAllyEffectStat> Delete(AbilityAllyEffectStat abilityAllyEffectStat)
    {
        return await _abilityAllyEffectStatRepository.UpdateAsync(abilityAllyEffectStat.Id, abilityAllyEffectStat);

    }
    public async Task<AbilityAllyEffectStat> Remove(AbilityAllyEffectStat abilityAllyEffectStat)
    {
        return await _abilityAllyEffectStatRepository.DeleteAsync(abilityAllyEffectStat);
    }

    public async Task<AbilityAllyEffectStat> Update(AbilityAllyEffectStat abilityAllyEffectStat)
    {
        return await _abilityAllyEffectStatRepository.UpdateAsync(abilityAllyEffectStat.Id, abilityAllyEffectStat);
    }
    public async Task<AbilityAllyEffectStat> GetById(string id)
    {
        return await _abilityAllyEffectStatRepository.GetAsync(x => x.Id.Equals(id));
    }

    public async Task<List<AbilityAllyEffectStat>> GetListByActive(int index = 0, int size = 10)
    {
        return await _abilityAllyEffectStatRepository.GetList(x => x.Status.Equals(true), index: index, size: size);
    }

    public async Task<List<AbilityAllyEffectStat>> GetListByInActive(int index = 0, int size = 10)
    {
        return await _abilityAllyEffectStatRepository.GetList(x => x.Status.Equals(false), index: index, size: size);
    }

}
