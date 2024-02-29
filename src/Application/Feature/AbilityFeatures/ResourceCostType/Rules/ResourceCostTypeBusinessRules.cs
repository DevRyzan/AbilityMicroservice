using Application.Feature.AbilityFeatures.ResourceCostType.Constants;
using Application.Service.Repositories;
using Core.Application;
using Core.CrossCuttingConcerns.Exceptions;

namespace Application.Feature.AbilityFeatures.ResourceCostType.Rules;

public class ResourceCostTypeBusinessRules : BaseBusinessRules
{
    private readonly IResourceCostTypeRepository _resourceCostTypeRepository;
    public ResourceCostTypeBusinessRules()
    {
        
    }

    public ResourceCostTypeBusinessRules(IResourceCostTypeRepository resourceCostTypeRepository)
    {
        _resourceCostTypeRepository = resourceCostTypeRepository;
    }

    public async Task PageRequestShouldBeValid(int index, int size)
    {
        if (index < 0 || size <= 0) throw new BusinessException(ResourceCostTypeMessages.PageRequestShouldBeValid);
    }
    public async Task IdShouldBeExist(string id)
    {
        Domain.Abilities.ResourceCostType resourceCostType = await _resourceCostTypeRepository.GetAsync(x => x.Id.Equals(id));
        if (resourceCostType == null) throw new BusinessException(ResourceCostTypeMessages.IdShouldBeExist);
    }
    public async Task RemoveCondition(string id)
    {
        Domain.Abilities.ResourceCostType resourceCostType = await _resourceCostTypeRepository.GetAsync(x => x.Id.Equals(id));
        if (resourceCostType.Status == true || resourceCostType.IsDeleted == false) throw new BusinessException(ResourceCostTypeMessages.RemoveCondition);
    }

}
