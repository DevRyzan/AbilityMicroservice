
using Application.Service.Repositories;
using Domain.Abilities;

namespace Application.Service.AbilityServices.AbilityAllyEffectStatService;

public class AbilityAllyEffectStatManager : IAbilityAllyEffectStatService
{
    private readonly IAbilityAllyEffectStatRepository _abilityAllyEffectStatRepository;

    public AbilityAllyEffectStatManager(IAbilityAllyEffectStatRepository abilityAllyEffectStatRepository)
    {
        _abilityAllyEffectStatRepository = abilityAllyEffectStatRepository;
    }

    public Task<AbilityAllyEffectStat> Create(AbilityAllyEffectStat abilityAllyEffectStat)
    {
        throw new NotImplementedException();
    }

    public Task<AbilityAllyEffectStat> Delete(AbilityAllyEffectStat abilityAllyEffectStat)
    {
        throw new NotImplementedException();
    }
    public Task<AbilityAllyEffectStat> Remove(AbilityAllyEffectStat abilityAllyEffectStat)
    {
        throw new NotImplementedException();
    }

    public Task<AbilityAllyEffectStat> Update(AbilityAllyEffectStat abilityAllyEffectStat)
    {
        throw new NotImplementedException();
    }
    public Task<AbilityAllyEffectStat> GetById(string id)
    {
        throw new NotImplementedException();
    }

    public Task<List<AbilityAllyEffectStat>> GetListByActive(int index = 0, int size = 10)
    {
        throw new NotImplementedException();
    }

    public Task<List<AbilityAllyEffectStat>> GetListByInActive(int index = 0, int size = 10)
    {
        throw new NotImplementedException();
    }
    
}
