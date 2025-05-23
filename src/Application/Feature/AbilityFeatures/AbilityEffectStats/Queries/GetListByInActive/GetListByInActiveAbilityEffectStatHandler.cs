﻿using Application.Feature.AbilityFeatures.AbilityEffectStats.Rules;
using Application.Service.AbilityServices.AbilityEffectStatService;
using AutoMapper;
using Domain.Abilities;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityEffectStats.Queries.GetListByInActive;

public class GetListByInActiveAbilityEffectStatHandler : IRequestHandler<GetListByInActiveAbilityEffectStatRequest, List<GetListByInActiveAbilityEffectStatResponse>>
{
    private readonly IAbilityEffectStatService _abilityEffectStatService;
    private readonly AbilityEffectStatBusinessRules _abilityEffectStatBusinessRules;
    private readonly IMapper _mapper;

    public GetListByInActiveAbilityEffectStatHandler(IAbilityEffectStatService abilityEffectStatService, AbilityEffectStatBusinessRules abilityEffectStatBusinessRules, IMapper mapper)
    {
        _abilityEffectStatService = abilityEffectStatService;
        _abilityEffectStatBusinessRules = abilityEffectStatBusinessRules;
        _mapper = mapper;
    }

    public async Task<List<GetListByInActiveAbilityEffectStatResponse>> Handle(GetListByInActiveAbilityEffectStatRequest request, CancellationToken cancellationToken)
    {
        // Ensure that the page request is valid using business rules.
        await _abilityEffectStatBusinessRules.PageRequestShouldBeValid(index: request.PageRequest.Page, size: request.PageRequest.PageSize);

        // Get the list of AbilityEffectStat entities by inactive status, paginated.
        List<AbilityEffectStat> abilityEffectTypes = await _abilityEffectStatService.GetListByInActive(index: request.PageRequest.Page, size: request.PageRequest.PageSize);

        // Map the list to the corresponding response DTOs.
        List<GetListByInActiveAbilityEffectStatResponse> mappedResponse = _mapper.Map<List<GetListByInActiveAbilityEffectStatResponse>>(abilityEffectTypes);

        // Return the mapped response.
        return mappedResponse;

    }
}
