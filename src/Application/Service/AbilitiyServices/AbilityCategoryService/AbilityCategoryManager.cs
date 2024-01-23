using Application.Service.Repositories;
using Core.Persistence.Paging;
using Domain.Abilities;
using System.Xml.Linq;

namespace Application.Service.AbilitiyServices.AbilityCategoryService;

public class AbilityCategoryManager : IAbilityCategoryService
{
    private readonly IAbilityCategoryRepository _abilityCategoryRepository;

    public AbilityCategoryManager(IAbilityCategoryRepository abilityCategoryRepository)
    {
        _abilityCategoryRepository = abilityCategoryRepository;
    }

    public async Task<AbilityCategory> Create(AbilityCategory abilityCategory)
    {
        return await _abilityCategoryRepository.AddAsync(abilityCategory);
    }

    public async Task<AbilityCategory> Delete(AbilityCategory abilityCategory)
    {
        return await _abilityCategoryRepository.UpdateAsync(abilityCategory.Id,abilityCategory);
    }

    public async Task<AbilityCategory> GetById(Guid id)
    {
        return await _abilityCategoryRepository.GetByIdAsync(id);
    }

    public async Task<AbilityCategory> GetByIdStatusFalse(Guid id)
    {
        return await _abilityCategoryRepository.GetAsync(x => x.Id.Equals(id) && x.Status.Equals(false));
    }

    public async Task<AbilityCategory> GetByIdStatusTrue(Guid id)
    {
        return await _abilityCategoryRepository.GetAsync(x => x.Id.Equals(id) && x.Status.Equals(false));
    }

    public async Task<AbilityCategory> GetByName(string name)
    {
        return await _abilityCategoryRepository.GetAsync(x => x.Name.Equals(name));
    }
    public Task<IPaginate<AbilityCategory>> GetListByInActive(int index = 0, int size = 10)
    {
        throw new NotImplementedException();
    }

    public Task<AbilityCategory> Remove(AbilityCategory abilityCategory)
    {
        throw new NotImplementedException();
    }

    public Task<AbilityCategory> Update(AbilityCategory abilityCategory)
    {
        throw new NotImplementedException();
    }

    Task<IPaginate<AbilityCategory>> IAbilityCategoryService.GetListByActive(int index, int size)
    {
        throw new NotImplementedException();
    }
}
