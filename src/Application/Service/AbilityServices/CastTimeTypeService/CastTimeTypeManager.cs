using Application.Service.Repositories;
using Domain.Abilities;

namespace Application.Service.AbilityServices.CastTimeTypeService;

public class CastTimeTypeManager : ICastTimeTypeService
{
    private readonly ICastTimeTypeRepository _castTimeTypeRepository;

    public CastTimeTypeManager(ICastTimeTypeRepository castTimeTypeRepository)
    {
        _castTimeTypeRepository = castTimeTypeRepository;
    }

    public async Task<CastTimeType> Create(CastTimeType castTimeType)
    {
        return await _castTimeTypeRepository.AddAsync(castTimeType);
    }

    public async Task<CastTimeType> Delete(CastTimeType castTimeType)
    {
        return await _castTimeTypeRepository.UpdateAsync(castTimeType.Id, castTimeType);
    }

    public async Task<List<CastTimeType>> GetActiveList(int index = 0, int size = 10)
    {
        return await _castTimeTypeRepository.GetList(x => x.Status.Equals(true), index: index, size: size);

    }

    public async Task<CastTimeType> GetById(string id)
    {
        return await _castTimeTypeRepository.GetAsync(x => x.Id.Equals(id));
    }

    public async Task<List<CastTimeType>> GetInActiveList(int index = 0, int size = 10)
    {
        return await _castTimeTypeRepository.GetList(x => x.Status.Equals(false), index: index, size: size);
    }

    public async Task<CastTimeType> Remove(CastTimeType castTimeType)
    {
        return await _castTimeTypeRepository.DeleteAsync(castTimeType);
    }

    public async Task<CastTimeType> Update(CastTimeType castTimeType)
    {
        return await _castTimeTypeRepository.UpdateAsync(castTimeType.Id, castTimeType);
    }
}
