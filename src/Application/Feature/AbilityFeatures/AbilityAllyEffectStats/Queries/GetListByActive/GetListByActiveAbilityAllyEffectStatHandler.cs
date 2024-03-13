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
        // Check the validity of the page request; it should comply with business rules.
        await _abilityAllyEffectStatsBusinessRules.PageRequestShouldBeValid(index: request.PageRequest.Page, size: request.PageRequest.PageSize);

        // Retrieve a list of active AbilityAllyEffectStats based on the active page and page size.
        List<AbilityAllyEffectStat> abilityAllyEffectStatList = await _abilityAllyEffectStatService.GetListByActive(index: request.PageRequest.Page, size: request.PageRequest.PageSize);

        // Map the list of active AbilityAllyEffectStats to the response DTO list.
        List<GetListByActiveAbilityAllyEffectStatResponse> mappedResponse = _mapper.Map<List<GetListByActiveAbilityAllyEffectStatResponse>>(abilityAllyEffectStatList);

        // Return the mapped response.
        return mappedResponse;

    }
}
