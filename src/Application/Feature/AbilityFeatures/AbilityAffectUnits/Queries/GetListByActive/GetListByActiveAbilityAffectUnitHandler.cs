﻿using Application.Feature.AbilityFeatures.AbilityAffectUnits.Rules;
using Application.Service.AbilityServices.AbilityAffectUnitService;
using AutoMapper;
using Domain.Abilities;
using MediatR;


namespace Application.Feature.AbilityFeatures.AbilityAffectUnits.Queries.GetListByActive;

public class GetListByActiveAbilityAffectUnitHandler : IRequestHandler<GetListByActiveAbilityAffectUnitRequest, List<GetListByActiveAbilityAffectUnitResponse>>
{
    private readonly IAbilityAffectUnitService _abilityAffectUnitService;
    private readonly AbilityAffectUnitBusinessRules _abilityAffectUnitBusinessRules;
    private readonly IMapper _mapper;

    public GetListByActiveAbilityAffectUnitHandler(IAbilityAffectUnitService abilityAffectUnitService, AbilityAffectUnitBusinessRules abilityAffectUnitBusinessRules, IMapper mapper)
    {
        _abilityAffectUnitService = abilityAffectUnitService;
        _abilityAffectUnitBusinessRules = abilityAffectUnitBusinessRules;
        _mapper = mapper;
    }

    public async Task<List<GetListByActiveAbilityAffectUnitResponse>> Handle(GetListByActiveAbilityAffectUnitRequest request, CancellationToken cancellationToken)
    {
        // Check the validity of the page request; it should comply with business rules.
        await _abilityAffectUnitBusinessRules.PageRequestShouldBeValid(index: request.PageRequest.Page, size: request.PageRequest.PageSize);

        // Retrieve a list of active AbilityAffectUnits based on the active page and page size.
        List<AbilityAffectUnit> abilityAffectUnitList = await _abilityAffectUnitService.GetListByActive(index: request.PageRequest.Page, size: request.PageRequest.PageSize);

        // Map the list of active AbilityAffectUnits to the response DTO list.
        List<GetListByActiveAbilityAffectUnitResponse> mappedResponse = _mapper.Map<List<GetListByActiveAbilityAffectUnitResponse>>(abilityAffectUnitList);

        // Return the mapped response.
        return mappedResponse;

    }
}
