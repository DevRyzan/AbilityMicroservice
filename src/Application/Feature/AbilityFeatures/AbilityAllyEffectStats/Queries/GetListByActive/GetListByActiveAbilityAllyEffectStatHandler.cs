using Application.Feature.AbilityFeatures.AbilityAllyEffectStats.Rules;
using Application.Service.AbilityServices.AbilityAllyEffectStatService;
using AutoMapper;
using Domain.Abilities;
using MediatR;


namespace Application.Feature.AbilityFeatures.AbilityAllyEffectStats.Queries.GetListByActive;

public class GetListByActiveAbilityAllyEffectStatHandler : IRequestHandler<GetListByActiveAbilityAllyEffectStatRequest, List<GetListByActiveAbilityAllyEffectStatResponse>>
{
    private readonly IAbilityAllyEffectStatService _abilityAllyEffectStatService;
    private readonly AbilityAllyEffectStatsBusinessRules _abilityAllyEffectStatsBusinessRules;
    private readonly IMapper _mapper;

    public GetListByActiveAbilityAllyEffectStatHandler(IAbilityAllyEffectStatService abilityAllyEffectStatService, AbilityAllyEffectStatsBusinessRules abilityAllyEffectStatsBusinessRules, IMapper mapper)
    {
        _abilityAllyEffectStatService = abilityAllyEffectStatService;
        _abilityAllyEffectStatsBusinessRules = abilityAllyEffectStatsBusinessRules;
        _mapper = mapper;
    }

    public async Task<List<GetListByActiveAbilityAllyEffectStatResponse>> Handle(GetListByActiveAbilityAllyEffectStatRequest request, CancellationToken cancellationToken)
    {
        await _abilityAllyEffectStatsBusinessRules.PageRequestShouldBeValid(index: request.PageRequest.Page, size: request.PageRequest.PageSize);

        List<AbilityAllyEffectStat> abilityAllyEffectStatList = await _abilityAllyEffectStatService.GetListByActive(index: request.PageRequest.Page, size: request.PageRequest.PageSize);

        List<GetListByActiveAbilityAllyEffectStatResponse> mappedResponse = _mapper.Map<List<GetListByActiveAbilityAllyEffectStatResponse>>(abilityAllyEffectStatList);
        return mappedResponse;
    }
}
