using Application.Feature.AbilityFeatures.AbilityEnemyEffectStats.Rules;
using Application.Service.AbilityServices.AbilityEnemyEffectStatService;
using AutoMapper;
using Domain.Abilities;
using MediatR;


namespace Application.Feature.AbilityFeatures.AbilityEnemyEffectStats.Queries.GetListByInActive;

public class GetListByInActiveAbilityEnemyEffectStatHandler : IRequestHandler<GetListByInActiveAbilityEnemyEffectStatRequest, List<GetListByInActiveAbilityEnemyEffectStatResponse>>
{
    private readonly IAbilityEnemyEffectStatService _abilityEnemyEffectStatService;
    private readonly AbilityEnemyEffectStatBusinessRules _abilityEnemyEffectStatBusinessRules;
    private readonly IMapper _mapper;

    public GetListByInActiveAbilityEnemyEffectStatHandler(IAbilityEnemyEffectStatService abilityEnemyEffectStatService, AbilityEnemyEffectStatBusinessRules abilityEnemyEffectStatBusinessRules, IMapper mapper)
    {
        _abilityEnemyEffectStatService = abilityEnemyEffectStatService;
        _abilityEnemyEffectStatBusinessRules = abilityEnemyEffectStatBusinessRules;
        _mapper = mapper;
    }

    public async Task<List<GetListByInActiveAbilityEnemyEffectStatResponse>> Handle(GetListByInActiveAbilityEnemyEffectStatRequest request, CancellationToken cancellationToken)
    {
        // Ensure that the page request is valid before proceeding
        await _abilityEnemyEffectStatBusinessRules.PageRequestShouldBeValid(index: request.PageRequest.Page, size: request.PageRequest.PageSize);

        // Retrieve a list of inactive AbilityEnemyEffectStat based on the specified page and page size
        List<AbilityEnemyEffectStat> abilityEnemyEffectStatList = await _abilityEnemyEffectStatService.GetListByInActive(index: request.PageRequest.Page, size: request.PageRequest.PageSize);

        // Map the list of AbilityEnemyEffectStat to the corresponding response DTOs
        List<GetListByInActiveAbilityEnemyEffectStatResponse> mappedResponse = _mapper.Map<List<GetListByInActiveAbilityEnemyEffectStatResponse>>(abilityEnemyEffectStatList);

        // Return the mapped response
        return mappedResponse;

    }
}
