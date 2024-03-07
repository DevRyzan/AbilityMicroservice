using Application.Service.Repositories;
using Domain.Abilities;


namespace Application.Service.AbilityServices.AbilityActivationTypeService;

public class AbilityActivationTypeManager : IAbilityActivationTypeService
{
    private readonly IAbilityActivationTypeRepository _abilityActivationTypeRepository;

    public AbilityActivationTypeManager(IAbilityActivationTypeRepository abilityActivationTypeRepository)
    {
        _abilityActivationTypeRepository = abilityActivationTypeRepository;
    }

    public async Task<AbilityActivationType> Create(AbilityActivationType abilityActivationType)
    {
        return await _abilityActivationTypeRepository.AddAsync(abilityActivationType);
    }

    public async Task<AbilityActivationType> Delete(AbilityActivationType abilityActivationType)
    {
        return await _abilityActivationTypeRepository.UpdateAsync(abilityActivationType.Id, abilityActivationType);
    }
    public async Task<AbilityActivationType> Remove(AbilityActivationType abilityActivationType)
    {
        return await _abilityActivationTypeRepository.DeleteAsync(abilityActivationType);
    }

    public async Task<AbilityActivationType> Update(AbilityActivationType abilityActivationType)
    {
        return await _abilityActivationTypeRepository.UpdateAsync(id: abilityActivationType.Id, entity: abilityActivationType);
    }
    public async Task<AbilityActivationType> GetById(string id)
    {
        return await _abilityActivationTypeRepository.GetAsync(x => x.Id.Equals(id));
    }

    public async Task<List<AbilityActivationType>> GetListByActive(int index = 0, int size = 10)
    {
        return await _abilityActivationTypeRepository.GetList(x => x.Status.Equals(true), index: index, size: size);
    }

    public async Task<List<AbilityActivationType>> GetListByInActive(int index = 0, int size = 10)
    {
        return await _abilityActivationTypeRepository.GetList(x => x.Status.Equals(false), index: index, size: size);
    }


}
