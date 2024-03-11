using Application.Feature.AbilityFeatures.AbilityEnemyEffectStats.Rules;
using Application.Service.AbilityServices.AbilityEnemyEffectStatService;
using AutoMapper;
using Domain.Abilities;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityEnemyEffectStats.Queries.GetListByActive;

public class GetListByActiveAbilityEnemyEffectStatHandler : IRequestHandler<GetListByActiveAbilityEnemyEffectStatRequest, List<GetListByActiveAbilityEnemyEffectStatResponse>>
{
    private readonly IAbilityEnemyEffectStatService _abilityEnemyEffectStatService;
    private readonly AbilityEnemyEffectStatBusinessRules _abilityEnemyEffectStatBusinessRules;
    private readonly IMapper _mapper;

    public GetListByActiveAbilityEnemyEffectStatHandler(IAbilityEnemyEffectStatService abilityEnemyEffectStatService, AbilityEnemyEffectStatBusinessRules abilityEnemyEffectStatBusinessRules, IMapper mapper)
    {
        _abilityEnemyEffectStatService = abilityEnemyEffectStatService;
        _abilityEnemyEffectStatBusinessRules = abilityEnemyEffectStatBusinessRules;
        _mapper = mapper;
    }

    public async Task<List<GetListByActiveAbilityEnemyEffectStatResponse>> Handle(GetListByActiveAbilityEnemyEffectStatRequest request, CancellationToken cancellationToken)
    {
        await _abilityEnemyEffectStatBusinessRules.PageRequestShouldBeValid(index: request.PageRequest.Page, size: request.PageRequest.PageSize);

        List<AbilityEnemyEffectStat> abilityEnemyEffectStatList = await _abilityEnemyEffectStatService.GetListByActive(index: request.PageRequest.Page, size: request.PageRequest.PageSize);

        List<GetListByActiveAbilityEnemyEffectStatResponse> mappedResponse = _mapper.Map<List<GetListByActiveAbilityEnemyEffectStatResponse>>(abilityEnemyEffectStatList);
        return mappedResponse;
    }
}
