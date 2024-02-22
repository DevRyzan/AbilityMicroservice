using Domain.Abilities;

namespace Application.Service.AbilityServices.ResourceCostTypeService;

public interface IResourceCostTypeService
{
    Task<ResourceCostType> Create(ResourceCostType resourceCostType);
    Task<ResourceCostType> Update(ResourceCostType resourceCostType);
    Task<ResourceCostType> Delete(ResourceCostType resourceCostType);
    Task<ResourceCostType> Remove(ResourceCostType resourceCostType);

    Task<ResourceCostType> GetById(string id);
    Task<List<ResourceCostType>> GetActiveList(int index = 0, int size = 10);
    Task<List<ResourceCostType>> GetInActiveList(int index = 0, int size = 10);
}
