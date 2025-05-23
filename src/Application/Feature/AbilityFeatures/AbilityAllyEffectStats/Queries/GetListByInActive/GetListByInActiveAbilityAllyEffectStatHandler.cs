﻿using Application.Feature.AbilityFeatures.AbilityAllyEffectStats.Rules;
using Application.Service.AbilityServices.AbilityAllyEffectStatService;
using AutoMapper;
using Domain.Abilities;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityAllyEffectStats.Queries.GetListByInActive;

public class GetListByInActiveAbilityAllyEffectStatHandler : IRequestHandler<GetListByInActiveAbilityAllyEffectStatRequest, List<GetListByInActiveAbilityAllyEffectStatResponse>>
{
    private readonly IAbilityAllyEffectStatService _abilityAllyEffectStatService;
    private readonly AbilityAllyEffectStatsBusinessRules _abilityAllyEffectStatsBusinessRules;
    private readonly IMapper _mapper;

    public GetListByInActiveAbilityAllyEffectStatHandler(IAbilityAllyEffectStatService abilityAllyEffectStatService, AbilityAllyEffectStatsBusinessRules abilityAllyEffectStatsBusinessRules, IMapper mapper)
    {
        _abilityAllyEffectStatService = abilityAllyEffectStatService;
        _abilityAllyEffectStatsBusinessRules = abilityAllyEffectStatsBusinessRules;
        _mapper = mapper;
    }

    public async Task<List<GetListByInActiveAbilityAllyEffectStatResponse>> Handle(GetListByInActiveAbilityAllyEffectStatRequest request, CancellationToken cancellationToken)
    {
        // Check the validity of the page request; it should comply with business rules.
        await _abilityAllyEffectStatsBusinessRules.PageRequestShouldBeValid(index: request.PageRequest.Page, size: request.PageRequest.PageSize);

        // Retrieve a list of inactive AbilityAllyEffectStats based on the active page and page size.
        List<AbilityAllyEffectStat> abilityAllyEffectStatList = await _abilityAllyEffectStatService.GetListByInActive(index: request.PageRequest.Page, size: request.PageRequest.PageSize);

        // Map the list of inactive AbilityAllyEffectStats to the response DTO list.
        List<GetListByInActiveAbilityAllyEffectStatResponse> mappedResponse = _mapper.Map<List<GetListByInActiveAbilityAllyEffectStatResponse>>(abilityAllyEffectStatList);

        // Return the mapped response.
        return mappedResponse;

    }
}
