using Application.Feature.AbilityFeatures.CastTimeTypes.Constants;
using Application.Feature.AbilityFeatures.ResourceCostType.Constants;
using Application.Service.Repositories;
using Core.Application;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Abilities;


namespace Application.Feature.AbilityFeatures.CastTimeTypes.Rules;

public class CastTimeTypeBusinessRules : BaseBusinessRules
{
    private readonly ICastTimeTypeRepository _castTimeTypeRepository;

    public CastTimeTypeBusinessRules(ICastTimeTypeRepository castTimeTypeRepository)
    {
        _castTimeTypeRepository = castTimeTypeRepository;
    }

    public async Task PageRequestShouldBeValid(int index, int size)
    {
        if (index < 0 || size <= 0) throw new BusinessException(ResourceCostTypeMessages.PageRequestShouldBeValid);
    }
    public async Task IdShouldBeExist(string id)
    {
        CastTimeType castTimeType = await _castTimeTypeRepository.GetAsync(x => x.Id.Equals(id));
        if (castTimeType == null) throw new BusinessException(CastTimeTypesMessages.IdShouldBeExist);
    }

    public async Task RemoveCondition(string id)
    {
        CastTimeType castTimeType = await _castTimeTypeRepository.GetAsync(x => x.Id.Equals(id));
        if (castTimeType.Status == true || castTimeType.IsDeleted == false) throw new BusinessException(CastTimeTypesMessages.RemoveCondition);
    }



}
