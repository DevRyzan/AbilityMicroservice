using Application.Service.Repositories;
using Domain.Abilities;

namespace Application.Service.AbilityServices.AbilityComboService;

public class AbilityComboManager : IAbilityComboService
{
    private readonly IAbilityComboRepository _abilityComboRepository;

    public AbilityComboManager(IAbilityComboRepository abilityComboRepository)
    {
        _abilityComboRepository = abilityComboRepository;
    }

    public async Task<AbilityCombo> Create(AbilityCombo abilityCombo)
    {
        return await _abilityComboRepository.AddAsync(abilityCombo);
    }

    public async Task<AbilityCombo> Delete(AbilityCombo abilityCombo)
    {
        return await _abilityComboRepository.UpdateAsync(abilityCombo.Id,abilityCombo);
    }

    public async Task<AbilityCombo> GetById(string id)
    {
        return await _abilityComboRepository.GetAsync(x => x.Id.Equals(id));
    }

    public async Task<List<AbilityCombo>> GetListByActive(int index = 0, int size = 10)
    {
        return await _abilityComboRepository.GetList(x => x.Status.Equals(true), index: index, size: size);
    }

    public async Task<List<AbilityCombo>> GetListByInActive(int index = 0, int size = 10)
    {
        return await _abilityComboRepository.GetList(x => x.Status.Equals(false), index: index, size: size);
    }

    public async Task<AbilityCombo> Remove(AbilityCombo abilityCombo)
    {
        return await _abilityComboRepository.DeleteAsync(abilityCombo);
    }

    public async Task<AbilityCombo> Update(AbilityCombo abilityCombo)
    {
        return await _abilityComboRepository.UpdateAsync(id: abilityCombo.Id, entity: abilityCombo);
    }
}
