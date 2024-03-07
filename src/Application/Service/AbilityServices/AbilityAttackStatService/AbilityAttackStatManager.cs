
using Application.Service.Repositories;
using Domain.Abilities;

namespace Application.Service.AbilityServices.AbilityAttackStatService;

public class AbilityAttackStatManager : IAbilityAttackStatService
{
    private readonly IAbilityAttackStatRepository _abilityAttackStatRepository;

    public AbilityAttackStatManager(IAbilityAttackStatRepository abilityAttackStatRepository)
    {
        _abilityAttackStatRepository = abilityAttackStatRepository;
    }

    public async Task<AbilityAttackStat> Create(AbilityAttackStat abilityAttackStat)
    {
        return await _abilityAttackStatRepository.AddAsync(abilityAttackStat);
    }

    public async Task<AbilityAttackStat> Delete(AbilityAttackStat abilityAttackStat)
    {
        return await _abilityAttackStatRepository.UpdateAsync(abilityAttackStat.Id, abilityAttackStat);
    }
    public async Task<AbilityAttackStat> Remove(AbilityAttackStat abilityAttackStat)
    {
        return await _abilityAttackStatRepository.DeleteAsync(abilityAttackStat);
    }

    public async Task<AbilityAttackStat> Update(AbilityAttackStat abilityAttackStat)
    {
        return await _abilityAttackStatRepository.UpdateAsync(id: abilityAttackStat.Id, entity: abilityAttackStat);
    }
    public async Task<AbilityAttackStat> GetById(string id)
    {
        return await _abilityAttackStatRepository.GetAsync(x => x.Id.Equals(id));
    }

    public async Task<List<AbilityAttackStat>> GetListByActive(int index = 0, int size = 10)
    {
        return await _abilityAttackStatRepository.GetList(x => x.Status.Equals(true), index: index, size: size);
    }

    public async Task<List<AbilityAttackStat>> GetListByInActive(int index = 0, int size = 10)
    {
        return await _abilityAttackStatRepository.GetList(x => x.Status.Equals(false), index: index, size: size);
    }

}
