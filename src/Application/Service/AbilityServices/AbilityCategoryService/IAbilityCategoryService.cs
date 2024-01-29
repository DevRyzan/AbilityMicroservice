using Core.Persistence.Paging;
using Domain.Abilities;

namespace Application.Service.AbilityServices.AbilityCategoryService;

public interface IAbilityCategoryService
{
    Task<AbilityCategory> Create(AbilityCategory abilityCategory);
    Task<AbilityCategory> Update(AbilityCategory abilityCategory);
    Task<AbilityCategory> Delete(AbilityCategory abilityCategory);
    Task<AbilityCategory> Remove(AbilityCategory abilityCategory);

    Task<AbilityCategory> GetById(Guid id);
    Task<AbilityCategory> GetByIdStatusTrue(Guid id);
    Task<AbilityCategory> GetByIdStatusFalse(Guid id);
}
