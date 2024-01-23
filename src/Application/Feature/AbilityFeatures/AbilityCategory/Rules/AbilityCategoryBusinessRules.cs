using Application.Service.Repositories;
using Core.Application;

namespace Application.Feature.AbilityFeatures.AbilityCategory.Rules;

public class AbilityCategoryBusinessRules : BaseBusinessRules
{
    private readonly IAbilityCategoryRepository _abilityCategoryRepository;

    public AbilityCategoryBusinessRules(IAbilityCategoryRepository abilityCategoryRepository)
    {
        _abilityCategoryRepository = abilityCategoryRepository;
    }
}
