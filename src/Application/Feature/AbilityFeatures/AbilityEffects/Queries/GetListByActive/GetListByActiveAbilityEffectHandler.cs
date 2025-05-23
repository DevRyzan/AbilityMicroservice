﻿using Application.Feature.AbilityFeatures.AbilityEffects.Rules;
using Application.Service.AbilityServices.AbilityEffectService;
using AutoMapper;
using Domain.Abilities;
using MediatR;


namespace Application.Feature.AbilityFeatures.AbilityEffects.Queries.GetListByActive;

public class GetListByActiveAbilityEffectHandler : IRequestHandler<GetListByActiveAbilityEffectRequest, List<GetListByActiveAbilityEffectResponse>>
{
    private readonly IAbilityEffectService _abilityEffectService;
    private readonly AbilityEffectBusinessRules _abilityEffectBusinessRules;
    private readonly IMapper _mapper;

    public GetListByActiveAbilityEffectHandler(IAbilityEffectService abilityEffectService, AbilityEffectBusinessRules abilityEffectBusinessRules, IMapper mapper)
    {
        _abilityEffectService = abilityEffectService;
        _abilityEffectBusinessRules = abilityEffectBusinessRules;
        _mapper = mapper;
    }

    public async Task<List<GetListByActiveAbilityEffectResponse>> Handle(GetListByActiveAbilityEffectRequest request, CancellationToken cancellationToken)
    {
        // Ensure that the provided page request is valid.
        await _abilityEffectBusinessRules.PageRequestShouldBeValid(index: request.PageRequest.Page, size: request.PageRequest.PageSize);

        // Retrieve a list of active AbilityEffect entities based on the page request.
        List<AbilityEffect> abilityEffects = await _abilityEffectService.GetListByActive(index: request.PageRequest.Page, size: request.PageRequest.PageSize);

        // Map the list of AbilityEffect entities to the response DTO list.
        List<GetListByActiveAbilityEffectResponse> mappedResponse = _mapper.Map<List<GetListByActiveAbilityEffectResponse>>(abilityEffects);

        // Return the mapped response list.
        return mappedResponse;

    }
}
