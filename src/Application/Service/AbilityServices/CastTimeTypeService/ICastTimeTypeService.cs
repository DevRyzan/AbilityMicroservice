using Domain.Abilities;


namespace Application.Service.AbilityServices.CastTimeTypeService;

public interface ICastTimeTypeService
{
    Task<CastTimeType> Create(CastTimeType castTimeType);
    Task<CastTimeType> Update(CastTimeType castTimeType);
    Task<CastTimeType> Delete(CastTimeType castTimeType);
    Task<CastTimeType> Remove(CastTimeType castTimeType);

    Task<CastTimeType> GetById(string id);
    Task<List<CastTimeType>> GetActiveList(int index = 0, int size = 10);
    Task<List<CastTimeType>> GetInActiveList(int index = 0, int size = 10);
}
