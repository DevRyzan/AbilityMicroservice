﻿using Application.Feature.AbilityFeatures.AbilityDamageTypes.Rules;
using Application.Service.AbilityServices.AbilityDamageTypeService;
using AutoMapper;
using Domain.Abilities;
using MediatR;


namespace Application.Feature.AbilityFeatures.AbilityDamageTypes.Queries.GetListByActive;

public class GetListByActiveAbilityDamageTypeHandler : IRequestHandler<GetListByActiveAbilityDamageTypeRequest, List<GetListByActiveAbilityDamageTypeResponse>>
{
    private readonly IAbilityDamageTypeService _abilityDamageTypeService;
    private readonly AbilityDamageTypeBusinessRules _abilityDamageTypeBusinessRules;
    private readonly IMapper _mapper;

    public GetListByActiveAbilityDamageTypeHandler(IAbilityDamageTypeService abilityDamageTypeService, AbilityDamageTypeBusinessRules abilityDamageTypeBusinessRules, IMapper mapper)
    {
        _abilityDamageTypeService = abilityDamageTypeService;
        _abilityDamageTypeBusinessRules = abilityDamageTypeBusinessRules;
        _mapper = mapper;
    }

    public async Task<List<GetListByActiveAbilityDamageTypeResponse>> Handle(GetListByActiveAbilityDamageTypeRequest request, CancellationToken cancellationToken)
    {
        // Check the validity of the page request parameters; they should comply with business rules.
        await _abilityDamageTypeBusinessRules.PageRequestShouldBeValid(index: request.PageRequest.Page, size: request.PageRequest.PageSize);

        // Retrieve a list of active AbilityDamageTypes based on the specified page index and size.
        List<AbilityDamageType> abilityDamageTypeList = await _abilityDamageTypeService.GetListByActive(index: request.PageRequest.Page, size: request.PageRequest.PageSize);

        // Map the list of AbilityDamageTypes to the response DTOs.
        List<GetListByActiveAbilityDamageTypeResponse> mappedResponse = _mapper.Map<List<GetListByActiveAbilityDamageTypeResponse>>(abilityDamageTypeList);

        // Return the mapped response.
        return mappedResponse;

    }
}
