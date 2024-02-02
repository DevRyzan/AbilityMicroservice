using Domain.Abilities;

namespace Application.Service.AbilityServices.AbilityTargetTypeDetailEngService;

public interface IAbilityTargetTypeDetailEngService
{
    Task<AbilityTargetTypeDetailEng> Create(AbilityTargetTypeDetailEng  abilityTargetTypeDetailEng);
    Task<AbilityTargetTypeDetailEng> Update(AbilityTargetTypeDetailEng abilityTargetTypeDetailEng);
    Task<AbilityTargetTypeDetailEng> Delete(AbilityTargetTypeDetailEng abilityTargetTypeDetailEng);
    Task<AbilityTargetTypeDetailEng> Remove(AbilityTargetTypeDetailEng abilityTargetTypeDetailEng);

    Task<AbilityTargetTypeDetailEng> GetById(Guid id);
    Task<List<AbilityTargetTypeDetailEng>> GetActiveList(int index = 0, int size = 10);
    Task<List<AbilityTargetTypeDetailEng>> GetInActiveList(int index = 0, int size = 10);
}
