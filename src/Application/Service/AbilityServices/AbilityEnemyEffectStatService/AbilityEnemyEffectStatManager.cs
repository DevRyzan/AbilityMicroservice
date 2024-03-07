using Application.Service.Repositories;
using Domain.Abilities;


namespace Application.Service.AbilityServices.AbilityEnemyEffectStatService;

public class AbilityEnemyEffectStatManager : IAbilityEnemyEffectStatService
{
    private readonly IAbilityEnemyEffectStatRepository _abilityEnemyEffectStatRepository;

    public AbilityEnemyEffectStatManager(IAbilityEnemyEffectStatRepository abilityEnemyEffectStatRepository)
    {
        _abilityEnemyEffectStatRepository = abilityEnemyEffectStatRepository;
    }

    public async Task<AbilityEnemyEffectStat> Create(AbilityEnemyEffectStat abilityEnemyEffectStat)
    {
        return await _abilityEnemyEffectStatRepository.AddAsync(abilityEnemyEffectStat);
    }

    public async Task<AbilityEnemyEffectStat> Delete(AbilityEnemyEffectStat abilityEnemyEffectStat)
    {
        return await _abilityEnemyEffectStatRepository.UpdateAsync(abilityEnemyEffectStat.Id, abilityEnemyEffectStat);
    }
    public async Task<AbilityEnemyEffectStat> Remove(AbilityEnemyEffectStat abilityEnemyEffectStat)
    {
        return await _abilityEnemyEffectStatRepository.DeleteAsync(abilityEnemyEffectStat);
    }

    public async Task<AbilityEnemyEffectStat> Update(AbilityEnemyEffectStat abilityEnemyEffectStat)
    {
        return await _abilityEnemyEffectStatRepository.UpdateAsync(abilityEnemyEffectStat.Id, abilityEnemyEffectStat);
    }
    public async Task<AbilityEnemyEffectStat> GetById(string id)
    {
        return await _abilityEnemyEffectStatRepository.GetAsync(x => x.Id.Equals(id));
    }

    public async Task<List<AbilityEnemyEffectStat>> GetListByActive(int index = 0, int size = 10)
    {
        return await _abilityEnemyEffectStatRepository.GetList(x => x.Status.Equals(true), index: index, size: size);
    }

    public async Task<List<AbilityEnemyEffectStat>> GetListByInActive(int index = 0, int size = 10)
    {
        return await _abilityEnemyEffectStatRepository.GetList(x => x.Status.Equals(false), index: index, size: size);
    }
}
