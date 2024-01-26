using Application.Service.Repositories;
using Core.Persistence.Paging;
using Domain.Abilities;

namespace Application.Service.AbilityServices.AbilityCategoryDetailEngService;

public class AbilityCategoryDetailEngManager : IAbilityCategoryDetailEngService
{
    private readonly IAbilityCategoryDetailEngRepository _abilityCategoryDetailEngRepository;

    public AbilityCategoryDetailEngManager(IAbilityCategoryDetailEngRepository abilityCategoryDetailEngRepository)
    {
        _abilityCategoryDetailEngRepository = abilityCategoryDetailEngRepository;
    }

    public async Task<AbilityCategoryDetailEng> Create(AbilityCategoryDetailEng abilityCategoryDetailEng)
    {
        return await _abilityCategoryDetailEngRepository.AddAsync(abilityCategoryDetailEng);
    }

    public Task<AbilityCategoryDetailEng> Delete(AbilityCategoryDetailEng abilityCategoryDetailEng)
    {
        throw new NotImplementedException();
    }

    public async Task<AbilityCategoryDetailEng> GetByAbilityId(Guid abilityCategoryId)
    {
        return await _abilityCategoryDetailEngRepository.GetAsync(x => x.AbilityCategoryId.Equals(abilityCategoryId));
    }

    public Task<AbilityCategory> GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<AbilityCategoryDetailEng>> GetListByActive(int index = 0, int size = 10)
    {
        return await _abilityCategoryDetailEngRepository.GetList(x => x.Status.Equals(true), index: index, size: size);
    }

    public async Task<AbilityCategoryDetailEng> Remove(AbilityCategoryDetailEng abilityCategoryDetailEng)
    {
        return await _abilityCategoryDetailEngRepository.DeleteAsync(entity: abilityCategoryDetailEng);
    }

    public async Task<AbilityCategoryDetailEng> Update(AbilityCategoryDetailEng abilityCategoryDetailEng)
    {

        return await _abilityCategoryDetailEngRepository.UpdateAsync(abilityCategoryDetailEng.Id, abilityCategoryDetailEng);
    }
}
