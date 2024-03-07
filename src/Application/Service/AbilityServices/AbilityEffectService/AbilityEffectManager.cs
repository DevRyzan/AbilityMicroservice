using Application.Service.Repositories;
using Domain.Abilities;

namespace Application.Service.AbilityServices.AbilityEffectService;

public class AbilityEffectManager : IAbilityEffectService
{
    private readonly IAbilityEffectRepository _abilityEffectRepository;

    public AbilityEffectManager(IAbilityEffectRepository abilityEffectRepository)
    {
        _abilityEffectRepository = abilityEffectRepository;
    }

    public async Task<AbilityEffect> Create(AbilityEffect abilityEffect)
    {
        return await _abilityEffectRepository.AddAsync(abilityEffect);
    }

    public async Task<AbilityEffect> Delete(AbilityEffect abilityEffect)
    {
        return await _abilityEffectRepository.UpdateAsync(abilityEffect.Id, abilityEffect);
    }
    public async Task<AbilityEffect> Remove(AbilityEffect abilityEffect)
    {
        return await _abilityEffectRepository.DeleteAsync(abilityEffect);
    }

    public async Task<AbilityEffect> Update(AbilityEffect abilityEffect)
    {
        return await _abilityEffectRepository.UpdateAsync(abilityEffect.Id, abilityEffect);
    }
    public async Task<AbilityEffect> GetById(string id)
    {
        return await _abilityEffectRepository.GetAsync(x => x.Id.Equals(id));
    }

    public async Task<List<AbilityEffect>> GetListByActive(int index = 0, int size = 10)
    {
        return await _abilityEffectRepository.GetList(x => x.Status.Equals(true), index: index, size: size);
    }

    public async Task<List<AbilityEffect>> GetListByInActive(int index = 0, int size = 10)
    {
        return await _abilityEffectRepository.GetList(x => x.Status.Equals(false), index: index, size: size);
    }
}
