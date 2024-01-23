using Core.Persistence.Paging;
using Domain.Abilities;

namespace Application.Service.AbilitiyServices.AbilityCategoryService;

public interface IAbilityCategoryService
{
    Task<AbilityCategory> Create(AbilityCategory abilityCategory);
    Task<AbilityCategory> Update(AbilityCategory abilityCategory);
    Task<AbilityCategory> Delete(AbilityCategory abilityCategory);
    Task<AbilityCategory> Remove(AbilityCategory abilityCategory);

    Task<AbilityCategory> GetById(Guid id);
    Task<AbilityCategory> GetByName(string name);
    Task<AbilityCategory> GetByIdStatusTrue(Guid id);
    Task<AbilityCategory> GetByIdStatusFalse(Guid id);

    Task<IPaginate<AbilityCategory>> GetListByActive(int index = 0, int size = 10);
    Task<IPaginate<AbilityCategory>> GetListByInActive(int index = 0, int size = 10);
}
