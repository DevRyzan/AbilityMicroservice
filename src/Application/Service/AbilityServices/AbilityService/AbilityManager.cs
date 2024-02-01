using Application.Service.Repositories;
using Domain.Abilities;

namespace Application.Service.AbilityServices.AbilityService;

public class AbilityManager : IAbilityService
{
    private readonly IAbilityRepository _abilityRepository;

    public AbilityManager(IAbilityRepository abilityRepository)
    {
        _abilityRepository = abilityRepository;
    }

    public async Task<Ability> Create(Ability ability)
    {
        return await _abilityRepository.AddAsync(ability);
    }

    public async Task<Ability> Delete(Ability ability)
    {
        return await _abilityRepository.UpdateAsync(ability.Id,ability);
    }

    public async Task<List<Ability>> GetActiveList(int index = 0, int size = 10)
    {
        return await _abilityRepository.GetList(x => x.Status.Equals(true), index: index, size: size);
    }

    public async Task<Ability> GetByHeroId(Guid heroId)
    {
        return await _abilityRepository.GetAsync(x => x.HeroId.Equals(heroId));
    }

    public async Task<Ability> GetById(Guid id)
    {
        return await _abilityRepository.GetAsync(x => x.Id.Equals(id));
    }

    public async Task<List<Ability>> GetInActiveList(int index = 0, int size = 10)
    {
        return await _abilityRepository.GetList(x => x.Status.Equals(false), size: size, index: index);
    }

    public async Task<Ability> Remove(Ability ability)
    {
        return await _abilityRepository.DeleteAsync(ability);
    }

    public async Task<Ability> Update(Ability ability)
    {
        return await _abilityRepository.UpdateAsync(ability.Id, ability);
    }
}
