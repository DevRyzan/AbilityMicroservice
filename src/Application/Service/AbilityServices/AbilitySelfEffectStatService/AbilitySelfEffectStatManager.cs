using Application.Service.Repositories;
using Domain.Abilities;


namespace Application.Service.AbilityServices.AbilitySelfEffectStatService;

public class AbilitySelfEffectStatManager : IAbilitySelfEffectStatService
{
    private readonly IAbilitySelfEffectStatRepository _abilitySelfEffectStatRepository;

    public AbilitySelfEffectStatManager(IAbilitySelfEffectStatRepository abilitySelfEffectStatRepository)
    {
        _abilitySelfEffectStatRepository = abilitySelfEffectStatRepository;
    }

    public async Task<AbilitySelfEffectStat> Create(AbilitySelfEffectStat abilitySelfEffectStat)
    {
        return await _abilitySelfEffectStatRepository.AddAsync(abilitySelfEffectStat);
    }

    public async Task<AbilitySelfEffectStat> Delete(AbilitySelfEffectStat abilitySelfEffectStat)
    {
        return await _abilitySelfEffectStatRepository.UpdateAsync(abilitySelfEffectStat.Id, abilitySelfEffectStat);
    }
    public async Task<AbilitySelfEffectStat> Remove(AbilitySelfEffectStat abilitySelfEffectStat)
    {
        return await _abilitySelfEffectStatRepository.DeleteAsync(abilitySelfEffectStat);
    }

    public async Task<AbilitySelfEffectStat> Update(AbilitySelfEffectStat abilitySelfEffectStat)
    {
        return await _abilitySelfEffectStatRepository.UpdateAsync(abilitySelfEffectStat.Id, abilitySelfEffectStat);
    }
    public async Task<AbilitySelfEffectStat> GetById(string id)
    {
        return await _abilitySelfEffectStatRepository.GetAsync(x => x.Id.Equals(id));
    }

    public async Task<List<AbilitySelfEffectStat>> GetListByActive(int index = 0, int size = 10)
    {
        return await _abilitySelfEffectStatRepository.GetList(x => x.Status.Equals(true), index: index, size: size);
    }

    public async Task<List<AbilitySelfEffectStat>> GetListByInActive(int index = 0, int size = 10)
    {
        return await _abilitySelfEffectStatRepository.GetList(x => x.Status.Equals(false), index: index, size: size);
    }
}
