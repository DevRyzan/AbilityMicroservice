using Application.Service.Repositories;
using Domain.Abilities;

namespace Application.Service.AbilityServices.ResourceCostTypeService;

public class ResourceCostTypeManager : IResourceCostTypeService
{
    private readonly IResourceCostTypeRepository _resourceCostTypeRepository;

    public ResourceCostTypeManager(IResourceCostTypeRepository resourceCostTypeRepository)
    {
        _resourceCostTypeRepository = resourceCostTypeRepository;
    }

    public async Task<ResourceCostType> Create(ResourceCostType resourceCostType)
    {
        return await _resourceCostTypeRepository.AddAsync(resourceCostType);
    }

    public async Task<ResourceCostType> Delete(ResourceCostType resourceCostType)
    {
        return await _resourceCostTypeRepository.UpdateAsync(resourceCostType.Id,resourceCostType);
    }

    public async Task<List<ResourceCostType>> GetActiveList(int index = 0, int size = 10)
    {
        return await _resourceCostTypeRepository.GetList(x => x.Status.Equals(true),index:index,size:size);
    }

    public async Task<ResourceCostType> GetById(string id)
    {
        return await _resourceCostTypeRepository.GetAsync(x => x.Id.Equals(id));
    }

    public async Task<List<ResourceCostType>> GetInActiveList(int index = 0, int size = 10)
    {
        return await _resourceCostTypeRepository.GetList(x => x.Status.Equals(false), index: index, size: size);
    }

    public async Task<ResourceCostType> Remove(ResourceCostType resourceCostType)
    {
        return await _resourceCostTypeRepository.DeleteAsync(resourceCostType);
    }

    public async Task<ResourceCostType> Update(ResourceCostType resourceCostType)
    {
        return await _resourceCostTypeRepository.UpdateAsync(resourceCostType.Id, resourceCostType);
    }
}
