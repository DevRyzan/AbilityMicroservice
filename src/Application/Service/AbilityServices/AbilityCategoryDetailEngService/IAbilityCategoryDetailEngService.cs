using Core.Persistence.Paging;
using Domain.Abilities;

namespace Application.Service.AbilityServices.AbilityCategoryDetailEngService;

public interface IAbilityCategoryDetailEngService
{
    Task<AbilityCategoryDetailEng> Create(AbilityCategoryDetailEng abilityCategoryDetailEng);
    Task<AbilityCategoryDetailEng> Update(AbilityCategoryDetailEng abilityCategoryDetailEng);
    Task<AbilityCategoryDetailEng> Delete(AbilityCategoryDetailEng abilityCategoryDetailEng);
    Task<AbilityCategoryDetailEng> Remove(AbilityCategoryDetailEng abilityCategoryDetailEng);

    Task<AbilityCategoryDetailEng> GetByAbilityId(Guid abilityId);

    Task<IPaginate<AbilityCategoryDetailEng>> GetListByActive(int index = 0, int size = 10);
}
